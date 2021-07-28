using Microsoft.EntityFrameworkCore;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.Common
{
    public interface IStructuralMetdataDBContext
    {
         DbSet<Category> Categories {get; set;}
         DbSet<Correspondence> Correspondences {get; set;}
         DbSet<Label> Labels {get; set;}
         DbSet<Level> Levels {get; set;}
         DbSet<Mapping> Mappings {get; set;}
         DbSet<MeasurementType> MeasurementTypes {get; set;}
         DbSet<MeasurementUnit> MeasurementUnits {get; set;}
         DbSet<Node> Nodes {get; set;}
         DbSet<NodeSet> NodeSets {get; set;}
         DbSet<RepresentedVariable> RepresentedVariables {get; set;}
         DbSet<UnitType> UnitTypes {get; set;}
         DbSet<ValueDomain> ValueDomains {get; set;}
         DbSet<Variable> Variables {get; set;}
    }
}