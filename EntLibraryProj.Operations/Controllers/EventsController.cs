using EntLibraryProj.Models;
using Microsoft.AspNetCore.Mvc;

public class EventsController : Controller
{

    // GET: Displays the Event Registration Form

    [HttpGet("Events/Register/{id}")]
    public IActionResult EventRegistrationForm(int id)
    {
        // Prepare the registration model with the Event ID
        var registration = new RegistrationModel
        {
            EventId = id
        };

        // Render the EventRegistrationForm view
        return View("EventRegistrationForm", registration);
    }

    // POST: Processes the submitted Event Registration Form

    [HttpPost("Events/Register")]
    public IActionResult EventRegistrationForm(RegistrationModel model)
    {
        if (ModelState.IsValid)
        {
            // Log the registration details (for debugging purposes)
            Console.WriteLine($"User registered for Event ID {model.EventId}: {model.Name}, {model.Email}, {model.PhoneNumber}");

            // Redirect to the confirmation view
            return RedirectToAction("EventsRegistrationConfirmation", new { id = model.EventId });
        }

        // If validation fails, re-display the form with error messages
        return View("EventRegistrationForm", model);
    }

    // GET: Displays the Registration Confirmation
        [HttpGet("Events/Confirmation/{id}")]
    public IActionResult EventsRegistrationConfirmation(int id)
    {
        // Set a success message for the user
        ViewData["Message"] = $"You have successfully registered for the Event {id}!";

        // Render the EventsRegistrationConfirmation view
        return View("EventsRegistrationConfirmation");
    }
}