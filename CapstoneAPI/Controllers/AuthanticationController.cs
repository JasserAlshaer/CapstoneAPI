using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapstoneAPI.DTOs;
using System;
using CapstoneAPI.Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;
using CapstoneAPI.Context;
using CapstoneAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CapstoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthanticationController : ControllerBase
    {
        private readonly CapstoneDbContext _context;
        public AuthanticationController(CapstoneDbContext context)
        {
            _context = context;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(SignInInputDTO input)
        {
            try
            {
                var orignialEmail = input.Email;
                input.Email = HashingHelper.HashValueWith384(input.Email);
                input.Password = HashingHelper.HashValueWith384(input.Password);
                var user = _context.Clients.Where(u => u.Email == input.Email &&
                u.Password == input.Password && u.IsLoggedIn == false).SingleOrDefault();
                if (user == null)
                {
                    return Ok("User not found");
                }

                Random random = new Random();
                var otp = random.Next(1111, 9999);
                user.OTPCode = otp.ToString();

                user.OTPExipry = DateTime.Now.AddMinutes(15);
                await MailingHelper.SendEmail(orignialEmail, user.OTPCode, "Sign In  OTP", "Complete Sign in Operation");
                _context.Update(user);
                _context.SaveChanges();

                return Ok("Check your emnail OTP has been sent!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SignOut(int userId)
        {
            try
            {
                var user = _context.Clients.Where(u => u.Id == userId && u.IsLoggedIn == true).SingleOrDefault();
                if (user == null)
                {
                    return Ok(false);
                }

                user.LastLoginTime = DateTime.Now;
                user.IsLoggedIn = false;

                _context.Update(user);
                _context.SaveChanges();

                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> ResetPersonPassword(ResetPersonPasswordInputDTO input)
        {
            try
            {
                input.Email = HashingHelper.HashValueWith384(input.Email);
                var user = _context.Clients.Where(u => u.Email == input.Email
           && u.IsLoggedIn == false).SingleOrDefault();
                if (user == null)
                {
                    return Ok(false);
                }
                if (input.Password != input.ConfirmPassword)
                {
                    return Ok(false);
                }
                user.Password = HashingHelper.HashValueWith384(input.ConfirmPassword);
                //user.OTPCode = null;
                //user.OTPExipry = null;

                _context.Update(user);
                _context.SaveChanges();

                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SignUp(SignUpInputDTO input)
        {
            try
            {
                //validation 
                if (await _context.Clients.AnyAsync(x => x.Email.ToLower().Equals(input.Email)))
                    throw new FriendlyException("Email Is Already Taken", 400);
                if (!await DataValidationHelper.IsValidCountryCode(input.CountryCodeId))
                    throw new FriendlyException("Your Country code Id Should be 1", 400);
                if (!await DataValidationHelper.IsValidBirthDay(input.DateofBirth))
                    throw new FriendlyException("Your Age Should be More Than 18", 400);
                if (!await DataValidationHelper.IsJordanianPhone(input.Phone))
                    throw new FriendlyException("Your Phone Should be in Jordanian Format", 400);
                if (!await DataValidationHelper.IsValidEmail(input.Email))
                    throw new FriendlyException("Invalid Email Format", 400);
                if (!await DataValidationHelper.IsStrongPassword(input.Password))
                    throw new FriendlyException("The password is weak. It must contain an uppercase letter, a lowercase letter, a number, and a special character, and be at least 8 characters long.", 400);
                if (!await DataValidationHelper.IsSingleLanguageFullName(input.FullName))
                    throw new FriendlyException("Your Name Should be in one language and With out special Character", 400);
                Client person = new Client();
                //hashing
                person.Email = HashingHelper.HashValueWith384(input.Email);
                person.Password = HashingHelper.HashValueWith384(input.Password);
                person.CreatedBy = "System";
                person.RoleId = 1;
                person.CreationDate = DateTime.Now;
                person.FullName = input.FullName;
                person.PhoneNumber = input.Phone;
                person.BirthDate = DateOnly.Parse(input.DateofBirth);
                person.CountryCodeId = input.CountryCodeId;
                person.Image = null;
                person.IsActive = true;
                person.IsLoggedIn = false;
                person.IsVerfied = false;
                Random random = new Random();
                var otp = random.Next(1111, 9999);
                person.OTPCode = otp.ToString();
                person.OTPExipry = DateTime.Now.AddMinutes(3);
                await MailingHelper.SendEmail(input.Email, person.OTPCode, "Sign Up  OTP", "Complete Sign Up Operation");
                _context.Clients.Add(person);
                _context.SaveChanges();
                return Ok("New User Has Been Updated");
            }
            catch (FriendlyException ex)
            {
                return StatusCode(ex.ErrorCode, "\t" + ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            //need to create profile for this user


        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SendOTP(string email)
        {
            try
            {
                if (!await _context.Clients.AnyAsync(x => x.Email.ToLower().Equals(email)))
                    throw new FriendlyException("Email Not Exist on The System ", 400);
                if (!await DataValidationHelper.IsValidEmail(email))
                    throw new FriendlyException("Invalid Email Format", 400);
                email = HashingHelper.HashValueWith384(email);
                var user = _context.Clients.Where(u => u.Email == email && u.IsLoggedIn == false).SingleOrDefault();
                if (user == null)
                {
                    return Ok(false);
                }
                Random otp = new Random();
                user.OTPCode = otp.Next(1111, 9999).ToString();
                user.OTPExipry = DateTime.Now.AddMinutes(3);
                await MailingHelper.SendEmail(email, user.OTPCode, "Reset Password OTP", "Complete Reset Password");

                _context.Update(user);
                _context.SaveChanges();

                return Ok(true);
            }
            catch (FriendlyException ex)
            {
                return StatusCode(ex.ErrorCode, "\t" + ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Verification(VerificationInputDTO input)
        {
            try
            {
                if (!await _context.Clients.AnyAsync(x => x.Email.ToLower().Equals(input.Email)))
                    throw new FriendlyException("Email Not Exist on The System ", 400);
                if (!await DataValidationHelper.IsValidEmail(input.Email))
                    throw new FriendlyException("Invalid Email Format", 400);
                if (!await DataValidationHelper.IsValidCodeFormat(input.OTPCode))
                    throw new FriendlyException("Invalid OTP Code Format", 400);
                if (!await DataValidationHelper.IsValidOperationType(input.Type))
                    throw new FriendlyException("Invalid Type For Operation", 400);

                input.Email = HashingHelper.HashValueWith384(input.Email);
                var user = _context.Clients.Where(u => (u.Email == input.Email || u.Email == input.Email) && u.OTPCode == input.OTPCode
                && u.IsLoggedIn == false && u.OTPExipry > DateTime.Now).SingleOrDefault();
                if (user == null)
                {
                    return Ok("User not found");
                }

                if (input.Type.Equals("Signup"))
                {
                    user.IsVerfied = true;
                    user.OTPExipry = null;
                    user.OTPCode = null;
                    _context.Update(user);
                    _context.SaveChanges();
                    return Ok("Your Account Is Verifyed");
                }
                else if (input.Type.Equals("SignIn"))
                {
                    user.LastLoginTime = DateTime.Now;
                    user.IsLoggedIn = true;
                    user.OTPExipry = null;
                    user.OTPCode = null;

                    _context.Update(user);
                    _context.SaveChanges();

                    var response = TokenHelper.GenerateJWTToken(user.Id.ToString(), "Client");
                    return Ok(response);
                }
                else if (input.Type.Equals("ResetPass"))
                {
                    user.OTPExipry = null;
                    user.OTPCode = null;
                    _context.Update(user);
                    _context.SaveChanges();

                    return Ok("Insert Your New Password Please");
                }
                else
                {
                    return BadRequest("Invalid Operation");
                }
            }
            catch (FriendlyException ex)
            {
                return StatusCode(ex.ErrorCode, "\t" + ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
