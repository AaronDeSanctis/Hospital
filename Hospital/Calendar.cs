using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hospital
{
    public class Calendar
    {
        static string[] Scopes = { CalendarService.Scope.Calendar };
        private string ApplicationName = "Google Calendar Hospital API";
        private string calendarID = "n8jhsq7f2jft4i4kpifle3g650@group.calendar.google.com";

        private static UserCredential Login()
        {
            UserCredential credentialObj;

            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                credentialObj = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", CancellationToken.None, new FileDataStore("Books.ListMyLibrary")).Result;
            }

            return credentialObj;
        }

        public Events GetEvents()
        {
            UserCredential credentialObj = Login();
            Events events = GetEventData(credentialObj);
            return events;
        }

        public string AddAppointment(DateTime appt, Patient patientObj, Doctor doctorObj)
        {
            UserCredential credentialObj = Login();
            string confirmation = AddEvent(appt, patientObj, doctorObj, credentialObj);
            return confirmation;
        }

        private Events GetEventData(UserCredential credentialObj)
        {

            // Create Google Calendar API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentialObj,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List(calendarID);
            DateTime today = DateTime.Now;
            request.TimeMin = today.AddMonths(-1);
            request.TimeMax = today.AddMonths(1);
            request.ShowDeleted = true;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = request.Execute();
            return events;
        }

        private string AddEvent(DateTime appt, Patient patientObj, Doctor doctorObj, UserCredential credential)
        {
            // Create Google Calendar API service
            string hospitalEmail = "chad.hilke@gmail.com";
            string hospitalLocation = "The Fake Hospital";
            string description = "Doctor's appointment";
            string summary = "Doctor's appointment";
            CalendarService service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Create Event
            Event newEvent = new Event()
            {
                Summary = summary,
                Location = hospitalLocation,
                Description = description,
                Start = new EventDateTime()
                {
                    DateTime = appt,
                    TimeZone = "America/Chicago",
                },
                End = new EventDateTime()
                {
                    DateTime = appt.AddHours(1),
                    TimeZone = "America/Chicago",
                },

                //Recurrence = new String[] { "RRULE:FREQ=DAILY;COUNT=2" },

                Attendees = new EventAttendee[] {
                    new EventAttendee() { DisplayName = patientObj.GiveName(), Email = patientObj.emailAddress },
                    new EventAttendee() { DisplayName = doctorObj.GiveName(), Email = hospitalEmail },
                },
                Reminders = new Event.RemindersData()
                {
                    UseDefault = false,
                    Overrides = new EventReminder[] {
                        new EventReminder() { Method = "email", Minutes = 24 * 60 },
                        //new EventReminder() { Method = "sms", Minutes = 10 },
                    }
                }
            };

            try
            {
                EventsResource.InsertRequest request = service.Events.Insert(newEvent, calendarID);
                Event createdEvent = request.Execute();
                string eventStr = String.Format("{0} set for {1}", createdEvent.Description, createdEvent.Start.DateTime.ToString());
                return "Appointment made " + eventStr;
            }
            catch
            {
                return "Appointment not made. Please call.";
            }
            
        }

    }
}

