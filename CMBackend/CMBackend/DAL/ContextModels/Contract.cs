using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMBackend.DAL.ContextModels
{
    [Table("contracts")]
    public class Contract
    {
        [Key]
        [Column("contractcode")]
        public required string ContractCode { get; set; }
        [Column("contractname")]
        public required string ContractName { get; set; }
        [Column("client")]
        public required string Client { get; set; }
    }
}
