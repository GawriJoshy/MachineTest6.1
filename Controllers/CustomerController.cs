using MachineTest6._1.Models;
using MachineTest6._1.Repository;
using MachineTest6._1.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachineTest6._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //data fields
        private readonly ICustomerRepository _customerRepository;
        //construction injection
        public CustomerController(ICustomerRepository employeeRepository)
        {
            _customerRepository = employeeRepository;
        }
        #region Get all employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerRegistration>>> GetEmployee()
        {
            return await _customerRepository.GetAllCustomer();
        }
        #endregion

        #region Add an employee
        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerRegistration customer)
        {
            //to get the validation of the body
            if (ModelState.IsValid)
            {
                try
                {
                    var c_id = await _customerRepository.AddCustomer(customer);
                    if (c_id > 0)
                    {
                        return Ok(c_id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion

        #region update an customer
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerRegistration customer)
        {
            //to get the validation of the body
            if (ModelState.IsValid)
            {
                try
                {
                    await _customerRepository.UpdateCustomer(customer);
                    return Ok(customer);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion

        #region GetCustomerById

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerRegistration>> GetCustomerById(int? id)
        {
            try
            {
                var customer = await _customerRepository.GetCustomerById(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return Ok(customer);
            }
            catch (Exception)
            {
                return BadRequest();

            }
        }

        #endregion

        #region delete employee

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteCustomer(int? id)
        {
            try
            {
                var customerid = await _customerRepository.DeleteCustomer(id);
                if (customerid > 0)
                {
                    return Ok(customerid);
                }
                else
                { return BadRequest(); }
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        #endregion

        #region get view model

        [HttpGet]
        [Route("vmodelEmployees")]
        public async Task<ActionResult<IEnumerable<CustomerLoan>>> Getemployeeview()
        {
            return await _customerRepository.GetViewModelCustomerLoan();
        }

        #endregion
    }
}
