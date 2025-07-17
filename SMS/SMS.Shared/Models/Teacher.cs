using System.ComponentModel.DataAnnotations;

namespace SMS.Shared.Models;

public enum Designation
{
    [Display(Name = "Junior Teacher")]
    JuniorTeacher,

    [Display(Name = "Senior Teacher")]
    SeniorTeacher,

    [Display(Name = "Class Teacher")]
    ClassTeacher,

    Tutor,

    Lecturer,

    [Display(Name = "Senior Lecturer")]
    SeniorLecturer,

    [Display(Name = "Assistant Professor")]
    AssistantProfessor,

    [Display(Name = "Associate Professor")]
    AssociateProfessor,

    Professor,

    [Display(Name = "Head of Department")]
    HeadOfDepartment,

    [Display(Name = "Dean of Faculty")]
    DeanOfFaculty,

    [Display(Name = "Principal")]
    Principal,

    [Display(Name = "Vice Chancellor")]
    ViceChancellor
}

public class Teacher : Person
{
    [Key]
    public int Id { get; set; }
    public string GovtNumber { get; set; } = String.Empty;
    public MaritalStatus? MaritalStatus { get; set; }
    public string? FacebookLink { get; set; }
    public string? TwitterLink { get; set; }
    public string? LinkedInLink { get; set; }
    public Designation Designation { get; set; }
}