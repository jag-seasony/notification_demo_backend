using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using NotificationsApp.Models;


namespace NotificationsApp.Controllers
{
    [Route("api/notifications")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly NotificationService _notificationService;

        public NotificationsController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("send-sms")]
        public async Task<IActionResult> SendSMSAsync()
        {
            await _notificationService.SendSMSAsync("Hello world", "4540141319");
            return Ok();
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmailAsync()
        {
            await _notificationService.SendEmailAsync("jag@seasony.dk", "Jacob Gervin", "Hello World", "Whats up?");
            return Ok();
        }
        [HttpPost("send-notification")]
        public async Task<IActionResult> SendNotification([FromBody] NotificationPayload payload)
        {


            // Extract information from the payload
            var temperature = payload.Temperature;
            var humidity = payload.Humidity;
            var coTwo = payload.CoTwo;
            var waitingTime = payload.WaitingTime;
            var batteryLevel = payload.BatteryLevel;
            var isBlocked = payload.IsBlocked;
            var status = payload.Status;
            var startingSoon = payload.StartingSoon;
            var isFlagged = payload.IsFlagged;
            var room = payload.Room;
            var robot = payload.Robot;
            var name = payload.Name;
            var email = payload.Email;
            var phoneNumber = payload.PhoneNumber;
            var routineName = payload.RoutineName;


            //Acceptable temperature range
            var minTemperature = 19;
            var maxTemperature = 22;
            //Acceptable Humidity range
            var minHumidity = 50;
            var maxHumidity = 90;
            //Acceptable CO2 range
            var minCoTwo = 1000;
            var maxCoTwo = 2000;
            //Acceptable Battery range
            var minBatteryLevel = 10;
            // Check conditions and trigger notifications

            if (temperature < minTemperature)
            {
                var tempdiffbelow = minTemperature - temperature;
                string smsmessage = $"Alert from Seasony:\nHi {name},\n\nwe've detected a temperature alert at {room}.\nIt's been measured at {temperature} degrees, which is {tempdiffbelow} degrees lower than normal range.\n\nSincerely, Seasony";
                string subject = $"Climate Alert";
                string emailmessage = $"Hi {name},\n\nwe've detected a temperature alert at {room}.\nIt's been measured at {temperature} degrees, which is {tempdiffbelow} degrees lower than normal range.\n\nSincerely, Seasony";
                await _notificationService.SendSMSAsync(smsmessage, phoneNumber);
                await _notificationService.SendEmailAsync(email, name, subject, emailmessage);

                if (isFlagged == true)
                {
                    // await _notificationService.SendEmailAsync("74d4838a.seasony.dk@emea.teams.ms", name, subject, emailmessage);
                }
            }
            else if (temperature > maxTemperature)
            {
                var tempdiffabove = temperature - maxTemperature;
                string smsmessage = $"Alert from Seasony:\nHi {name},\n\nwe've detected a temperature alert at {room}.\nIt's been measured at {temperature} degrees, which is {tempdiffabove} degrees higher than normal range.\n\nSincerely, Seasony";
                string subject = $"Climate Alert";
                string emailmessage = $"Hi {name},\n\nwe've detected a temperature alert at {room}.\nIt's been measured at {temperature} degrees, which is {tempdiffabove} degrees higher than normal range.\n\nSincerely, Seasony";
                await _notificationService.SendSMSAsync(smsmessage, phoneNumber);
                await _notificationService.SendEmailAsync(email, name, subject, emailmessage);
            }
            else if (humidity < minHumidity)
            {
                var humdiffbelow = minHumidity - humidity;
                string smsmessage = $"Alert from Seasony:\nHi {name},\n\nwe've detected a humidity alert at {room}.\nIt's been measured at {humidity}%, which is {humdiffbelow}% lower than normal range.\n\nSincerely, Seasony";
                string subject = $"Climate Alert";
                string emailmessage = $"Hi {name},\n\nwe've detected a humidity alert at {room}.\nIt's been measured at {humidity}%, which is {humdiffbelow}% lower than normal range.\n\nSincerely, Seasony";
                await _notificationService.SendSMSAsync(smsmessage, phoneNumber);
                await _notificationService.SendEmailAsync(email, name, subject, emailmessage);
            }
            else if (humidity > maxHumidity)
            {
                var humdiffabove = humidity - maxHumidity;
                string smsmessage = $"Alert from Seasony:\nHi {name},\n\nwe've detected a humidity alert at {room}.\nIt's been measured at {humidity}%, which is {humdiffabove}% higher than normal range.\n\nSincerely, Seasony";
                string subject = $"Climate Alert";
                string emailmessage = $"Hi {name},\n\nwe've detected a humidity alert at {room}.\nIt's been measured at {humidity}%, which is {humdiffabove}% higher than normal range.\n\nSincerely, Seasony";
                await _notificationService.SendSMSAsync(smsmessage, phoneNumber);
                await _notificationService.SendEmailAsync(email, name, subject, emailmessage);
            }
            else if (coTwo < minCoTwo)
            {
                var cotwodiffbelow = minCoTwo - coTwo;
                string smsmessage = $"Alert from Seasony:\nHi {name},\n\nwe've detected a CO2 alert at {room}.\nIt's been measured at {coTwo} ppm, which is {cotwodiffbelow} ppm lower than normal range.\n\nSincerely, Seasony";
                string subject = $"Climate Alert";
                string emailmessage = $"Hi {name},\n\nwe've detected a humidity alert at {room}.\nIt's been measured at {coTwo} ppm, which is {cotwodiffbelow} ppm lower than normal range.\n\nSincerely, Seasony";
                await _notificationService.SendSMSAsync(smsmessage, phoneNumber);
                await _notificationService.SendEmailAsync(email, name, subject, emailmessage);
            }
            else if (coTwo > maxCoTwo)
            {
                var cotwodiffabove = coTwo - maxCoTwo;
                string smsmessage = $"Alert from Seasony:\nHi {name},\n\nwe've detected a CO2 alert at {room}.\nIt's been measured at {coTwo} ppm, which is {cotwodiffabove} ppm higher than normal range.\n\nSincerely, Seasony";
                string subject = $"Climate Alert";
                string emailmessage = $"Hi {name},\n\nwe've detected a humidity alert at {room}.\nIt's been measured at {coTwo} ppm, which is {cotwodiffabove} ppm higher than normal range.\n\nSincerely, Seasony";
                await _notificationService.SendSMSAsync(smsmessage, phoneNumber);
                await _notificationService.SendEmailAsync(email, name, subject, emailmessage);
            }
            else if (batteryLevel == 0)
            {
                string smsmessage = $"Alert from Seasony:\nHi {name},\n\nRobot {robot} ran out of battery.\n\nSincerely, Seasony";
                string subject = $"Robot {robot} ran out of battery";
                string emailmessage = $"Hi {name},\n\nRobot {robot} ran out of battery.\n\nSincerely, Seasony";
                await _notificationService.SendSMSAsync(smsmessage, phoneNumber);
                await _notificationService.SendEmailAsync(email, name, subject, emailmessage);
            }
            else if (batteryLevel < minBatteryLevel)
            {
                string smsmessage = $"Alert from Seasony:\nHi {name},\n\nRobot {robot} has less than 10% battery left.\n\nSincerely, Seasony";
                string subject = $"Robot {robot} is low on battery";
                string emailmessage = $"Hi {name},\n\nRobot {robot} is low on battery.\n\nSincerely, Seasony";
                await _notificationService.SendSMSAsync(smsmessage, phoneNumber);
                await _notificationService.SendEmailAsync(email, name, subject, emailmessage);
            }
            else if (isBlocked == true)
            {
                string smsmessage = $"Alert from Seasony:\nHi {name},\n\nRobot {robot} has stopped because it could not navigate an obstacle.\n\nSincerely, Seasony";
                string subject = $"Robot {robot} has stopped because it could not navigate an obstacle";
                string emailmessage = $"Hi {name},\n\nRobot {robot} has stopped because it could not navigate an obstacle.\n\nSincerely, Seasony";
                await _notificationService.SendSMSAsync("Blocked", phoneNumber);
                await _notificationService.SendEmailAsync(email, name, subject, emailmessage);
            }
            else if (status == "Cancelled")
            {
                string smsmessage = $"Alert from Seasony:\nHi {name},\n\nRoutine '{routineName}' has been cancelled.\n\nSincerely, Seasony";
                string subject = $"The routine {routineName} has been cancelled";
                string emailmessage = $"Hi {name},\n\nRoutine '{routineName}' has been cancelled\n\nSincerely, Seasony";
                await _notificationService.SendSMSAsync(smsmessage, phoneNumber);
                await _notificationService.SendEmailAsync(email, name, subject, emailmessage);
            }
            else if (status == "Finished")
            {
                string smsmessage = $"Alert from Seasony:\nHi {name},\n\nRoutine '{routineName}' has finished.\n\nSincerely, Seasony";
                string subject = $"The routine {routineName} has finished";
                string emailmessage = $"Hi {name},\n\nRoutine '{routineName}' has finished\n\nSincerely, Seasony";
                await _notificationService.SendSMSAsync(smsmessage, phoneNumber);
                await _notificationService.SendEmailAsync(email, name, subject, emailmessage);
            }
            else if (status == "Issue")
            {
                string smsmessage = $"Alert from Seasony:\nHi {name},\n\nRoutine '{routineName}' had an issue.\n\nSincerely, Seasony";
                string subject = $"The routine {routineName} had an issue";
                string emailmessage = $"Hi {name},\n\nRoutine '{routineName}' had an issue\n\nSincerely, Seasony";
                await _notificationService.SendSMSAsync(smsmessage, phoneNumber);
                await _notificationService.SendEmailAsync(email, name, subject, emailmessage);
            }
            // else if (startingSoon == true)
            // {
            //     string smsmessage = $"Alert from Seasony:\nHi {name},\n\nRoutine '{routineName}' had an issue.\n\nSincerely, Seasony";
            //     await _notificationService.SendSMSAsync("Starting soon", phoneNumber);
            //     await _notificationService.SendEmailAsync(email, name, subject, emailmessage);
            // }
            if (isFlagged == true)
            {
                //Send teams notification
            }
            // Add more conditions and notifications as needed

            return Ok();
        }
    }
}