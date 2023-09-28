using apitesting.DTOs;
using apitesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api
{
    public class CartModelUnitTest
    {
        string userEmail = "user@example.com";

        [Fact]
        public void ConstructorTakesUserEmail()
        {
            // Instantiate a Cart object using the constructor
            CartModel Obj = new CartModel(userEmail);
            Assert.Same(userEmail, Obj.Email);
        }

        [Fact]
        public void ConstructorSetsCostToZero()
        {
            // Instantiate a Cart object using the constructor
            CartModel Obj = new CartModel(userEmail);
            Assert.Equal(0, Obj.Cost);
        }
    }
}
