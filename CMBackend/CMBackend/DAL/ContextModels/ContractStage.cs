using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMBackend.DAL.ContextModels
{
    [Table("contractstages")]
    public class ContractStage
    {
        [Key]
        [Column("stagename")]
        public required string StageName { get; set; }
        [Column("startdate")]
        public DateOnly StartDate { get; set; }
        [Column("enddate")]
        public DateOnly EndDate { get; set; }
    }
}
