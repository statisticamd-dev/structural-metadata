using System;
using System.Collections.Generic;
using System.Linq;
using Presentation.Application.Common.Utils;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.NodeSets.StatisticalClassifications.Commands.UploadStatisticalClassificationCommand.translator
{
    public static class UploadCommandTranslator
    {


        private static StatisticalClassificationItemCsv GetParent(List<StatisticalClassificationItemCsv> list,  StatisticalClassificationItemCsv child) 
        {
            if(child == null || String.IsNullOrWhiteSpace(child.ParentCode))
            {
                return null;
            } 
            return list.Where(u => u.Code == child.ParentCode).FirstOrDefault();
        }

        private static List<StatisticalClassificationItemCsv> GetRootNodes(List<StatisticalClassificationItemCsv> list) 
        {
            return list.Where(u => String.IsNullOrWhiteSpace(u.ParentCode)).ToList();
        }

        private static List<StatisticalClassificationItemCsv> GetChildren(List<StatisticalClassificationItemCsv> list, StatisticalClassificationItemCsv parent)
        {
            if(parent == null)
            {
                return null;
            }
            return list.Where(u => u.ParentCode == parent.Code).ToList();
        }
        public static List<StatisticalClassificationItemCsv> ReadCSV(string csv) 
        {
            return  CSVRecordReader<StatisticalClassificationItemCsv>
                    .Read(csv)
                    .ToList();
        }

        public static void Translate(List<StatisticalClassificationItemCsv> csvItems, NodeSet statisticalClassification) {
           
            foreach(StatisticalClassificationItemCsv csvItem in csvItems)
            {
                statisticalClassification.Nodes.Add(creaetNode(statisticalClassification, csvItem.Code, csvItem.LabelId));
            }
        }

        public static void Translate(List<StatisticalClassificationItemCsv> csvItems, NodeSet statisticalClassification, AggregationType aggregationType)
        {
            foreach(Level level in statisticalClassification.Levels.OrderBy(l => l.LevelNumber))
            {
                foreach(StatisticalClassificationItemCsv csvItem in 
                    csvItems.Where(u => u.LevelNumber == level.LevelNumber))
                {
                    Node parent = statisticalClassification.Nodes
                        .Where(n => n.Code.Equals(csvItem.ParentCode)).FirstOrDefault();
                    statisticalClassification.Nodes
                        .Add(createLevelNode(statisticalClassification, parent, level, csvItem.Code, csvItem.LabelId, aggregationType));
                }
            }
        }

        public static void TranslateRecursivly(List<StatisticalClassificationItemCsv> csvItems, NodeSet statisticalClassification, AggregationType aggregationType) 
        {
            
            createNodeRecursivly(statisticalClassification, csvItems, GetRootNodes(csvItems), aggregationType);
        }


        private static Node creaetNode(NodeSet statisticalClassification, string code, long labelId) 
        {
            Node node = new Node() 
            {
                NodeSet = statisticalClassification,
                Code = code,
                AggregationType = AggregationType.NONE,
                LabelId = labelId
            };
            return node;
        }

        private static Node createLevelNode(NodeSet statisticalClassification, Node parent, Level level, string code, long labelId, AggregationType aggregationType)
        {
            Node node = new Node() 
            {
                Parent = parent,
                Level = level,
                NodeSet = statisticalClassification,
                Code = code,
                AggregationType = aggregationType,
                LabelId =  labelId
            };

             return node;
        }

        private static List<Node> createNodeRecursivly(NodeSet statisticalClassification, List<StatisticalClassificationItemCsv> csvItems, List<StatisticalClassificationItemCsv> rootNodes, AggregationType aggregationType)
        {
            if(rootNodes == null || rootNodes.Count == 0) {
                return null;
            }

            List<Node> nodes = new List<Node>();

            foreach( StatisticalClassificationItemCsv item in rootNodes)
            {
                Node node = new Node() 
                {
                    Code = item.Code,
                    AggregationType = aggregationType,
                    Level = statisticalClassification.Levels.Where(l => l.LevelNumber == item.LevelNumber).FirstOrDefault(),
                    LabelId =  item.LabelId,
                    NodeSet = statisticalClassification,
                    Children = createNodeRecursivly(statisticalClassification, csvItems, GetChildren(csvItems,item), aggregationType)
                };
                nodes.Add(node);
                statisticalClassification.Nodes.Add(node);
            }
            return nodes;
        }
    }
}
