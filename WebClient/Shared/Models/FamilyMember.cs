using System;

public class FamilyMember
{
    public Guid id = Guid.Empty;
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string email { get; set; }
    public string role { get; set; }
    public string avtar { get; set; }

    public void clear() {
        this.id = Guid.Empty;
        this.firstname = string.Empty;
        this.lastname = string.Empty;
        this.email = string.Empty;
        this.role = string.Empty;
        this.avtar = string.Empty;
    }
}
