using MachineTest6._1.Models;
using MachineTest6._1.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachineTest6._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        //data fields
        private readonly ILoanRepository _customerRepository;
        //construction injection
        public LoanController(ILoanRepository employeeRepository)
        {
            _customerRepository = employeeRepository;
        }
        #region Get all employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanDetails>>> GetLoan()
        {
            return await _customerRepository.GetAllLoan();
        }
        #endregion

        #region Add an employee
        [HttpPost]
        public async Task<IActionResult> AddLoan([FromBody] LoanDetails loan)
        {
            //to get the validation of the body
            if (ModelState.IsValid)
            {
                try
                {
                    var c_id = await _customerRepository.AddLoan(loan);
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
        public async Task<IActionResult> Updateloan([FromBody] LoanDetails loan)
        {
            //to get the validation of the body
            if (ModelState.IsValid)
            {
                try
                {
                    await _customerRepository.UpdateLoan(loan);
                    return Ok(loan);
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
        public async Task<ActionResult<LoanDetails>> GetLoanById(int? id)
        {
            try
            {
                var loan = await _customerRepository.GetLoanById(id);
                if (loan == null)
                {
                    return NotFound();
                }
                return Ok(loan);
            }
            catch (Exception)
            {
                return BadRequest();

            }
        }

        #endregion
    }
}
