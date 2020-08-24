﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineMarks.Data.ViewModels.Auth;
using OnlineMarks.Data.ViewModels.Subjects;
using OnlineMarks.Data.ViewModels.Users;
using OnlineMarks.Interfaces.Services;
using OnlineMarks.Tools.Enums;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace OnlineMarks.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [AllowAnonymous]
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var subjects = _subjectService.GetAll();
            return Ok(subjects);
        }

        [Authorize(Roles = UserRole.Admin)]
        [HttpPost("add")]
        public IActionResult Add([FromBody] SubjectView subjectView)
        {
            _subjectService.Add(subjectView.Name, subjectView.Professor);
            //return CreatedAtRoute("Add Subject", new { id = subjectView.Name }, subjectView);
            return Ok("You have successfully added " + subjectView.Name + "!");
        }

        [Authorize(Roles = UserRole.Admin)]
        [HttpPost("add/student")]
        public IActionResult AddStudent([FromBody] SubjectStudentInputView subjectStudentView)
        {
            _subjectService.AddStudent(subjectStudentView.SubjectName, subjectStudentView.StudentName);
            return Ok("You have successfully added " + subjectStudentView.StudentName + " to " + subjectStudentView.SubjectName + "!");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get([FromBody] SubjectView subjectView)
        {
            var user = _subjectService.GetByName(subjectView.Name);
            return Ok(user);
        }
    }
}
