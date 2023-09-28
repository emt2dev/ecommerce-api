using apitesting.DTOs;
using apitesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api
{
    public class NoteModelTest
    {
        [Fact]
        public void ConstructorTakesUserEmail()
        {
            NoteModel Obj = new NoteModel();
            Assert.Same("SystemDefault", Obj.EmployeeEmail);
        }
    }
}
