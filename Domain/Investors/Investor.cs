using Domain.Common;

namespace Domain.Investors;

public class Investor : IEntity
{
    public Guid Id { get; set; }
    public DateTime? CreationDate { get; set; }
    public DateTime? LastEditDate { get; set; }
    public int Status { get; set; }
    public string FirstName { get; set; }
}