using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FileHandlingApi.Dtos;
using FileHandlingApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FileHandlingApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {


        [HttpGet]
        public IActionResult GetCust()
        {
            return Ok("wollup");
        }
        
        [HttpPost]
        public IActionResult Save(RequestDto req)
        {
            try
            {
                if(req != null)
                {
                    var cust = new Customer
                    {
                        Name = req.Name,
                        Email = req.Email,
                        Phone = req.Phone,
                        DateCreated = DateTime.Now
                    };

                    var custToSave = JsonConvert.SerializeObject(cust);

                    //System.IO.File.AppendAllText("C:/Cust/list.txt", custToSave);

                    //alternative way
                    using(var writer = new StreamWriter("C:/Cust/list.txt",true))
                    {
                        writer.WriteLine(custToSave);
                    }
                   
                }
                else
                {
                    return BadRequest(new ResponseDto
                    {
                        Message = "Failed",
                        Status = false,
                        Data = null
                    });
                }

                return Ok(new ResponseDto
                {
                    Message = " Success",
                    Status = true,
                    Data = null
                });
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto
                {
                    Data = null,
                    Message = "Internal Server Error",
                    Status = false
                });
            }
           // return Ok();
        }


        public IActionResult GetList()
        {
            try
            {
                //to get all files in the list
                var customers = new List<Customer>();

                var custs = System.IO.File.ReadAllLines("C:/Cust/list.txt");

                foreach( var item in custs)
                {
                    var x = JsonConvert.DeserializeObject<Customer>(item);
                    customers.Add(x);
                }
                return Ok(customers);
            }
            catch(Exception ex)
            {

            }
            return Ok();
        }
    }
}