using Microsoft.AspNetCore.Mvc;
using SMS.Shared.Models;
using SMS.Shared.Interfaces;

namespace SMS.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;
    
    public StudentController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    [HttpGet("all-students")]
    public async Task<ActionResult<List<Student>>> GetAllStudentsAsync()
    {
        var students = await _studentRepository.GetAllStudentsAsync();
        return Ok(students);
    }

    [HttpGet("single-student/{id}")]
    public async Task<ActionResult<Student>> GetSingleStudentAsync(int id)
    {
        var student = await _studentRepository.GetStudentByIdAsync(id);
        return Ok(student);
    }
    
    [HttpPost("add-student")]
    public async Task<ActionResult<Student>> AddNewStudentAsync(Student student)
    {
        var newStudent = await _studentRepository.AddStudentAsync(student);
        return Ok(newStudent);
    }
    
    [HttpDelete("delete-student/{id}")]
    public async Task<ActionResult<Student>> DeleteStudentAsync(int id)
    {
        var student = await _studentRepository.DeleteStudentAsync(id);
        return Ok(student);
    }
    
    [HttpPut("update-student")]
    public async Task<ActionResult<Student>> UpdateStudentAsync(Student student)
    {
        var newStudent = await _studentRepository.UpdateStudentAsync(student);
        return Ok(newStudent);
    }
}