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
        static string ApplicationName = "Google Calendar Hospital API";
        //(Calendar ID: n8jhsq7f2jft4i4kpifle3g650 @group.calendar.google.com)
        static string calendarID = "n8jhsq7f2jft4i4kpifle3g650@group.calendar.google.com";

        private static UserCredential Login()
        {
            UserCredential credential;

            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {

                //credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets{ClientId = "PUT_CLIENT_ID_HERE", ClientSecret = "PUT_CLIENT_SECRETS_HERE"},
                //                new[] { BooksService.Scope.Books }, "user", CancellationToken.None, new FileDataStore(credPath, true));

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", CancellationToken.None, new FileDataStore("Books.ListMyLibrary")).Result;
                //Console.WriteLine("Credential file saved to: " + credPath);
            }

            return credential;
        }

        public void GetEvents()
        {
            //UserCredential credential = Login();

            GetEventData();
        }

        public string AddAppointment(DateTime appt, Patient p, Doctor dr)
        {
            UserCredential credential = Login();
            string confirmation = AddEvent(appt, p, dr, credential);
            return confirmation;
        }


        private void GetEventData()
        {
            UserCredential credential;

            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {

                //credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets{ClientId = "PUT_CLIENT_ID_HERE", ClientSecret = "PUT_CLIENT_SECRETS_HERE"},
                //                new[] { BooksService.Scope.Books }, "user", CancellationToken.None, new FileDataStore(credPath, true));

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", CancellationToken.None, new FileDataStore("Books.ListMyLibrary")).Result;
            }

            // Create Google Calendar API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List(calendarID);
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Console.WriteLine("Upcoming events:");
            Events events = request.Execute();
            if (events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    string when = eventItem.Start.DateTime.ToString();
                    if (String.IsNullOrEmpty(when))
                    {
                        when = eventItem.Start.Date;
                    }
                    Console.WriteLine("{0} ({1})", eventItem.Summary, when);
                }
            }
            else
            {
                Console.WriteLine("No upcoming events found.");
            }
            Console.Read();
        }

        private string AddEvent(DateTime appt, Patient patient, Doctor doctor, UserCredential credential)
        {
            // Create Google Calendar API service.
            CalendarService service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            //string googleUserName = "falagard@gmail.com";
            //string googlePassword = "winnie";
            //Uri calendarUri = GetGoogleCalendarUri();

            //Initialize Calendar Service
            //CalendarService service = new CalendarService("AIConsole");
            //service.setUserCredentials(googleUserName, googlePassword);

            Event newEvent = new Event()
            {
                Summary = "Doctor's appointment ",
                Location = "The Fake Hospital",
                Description = "Problems with your prostate.",
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
                    new EventAttendee() { DisplayName = patient.name, Email = "chad.hilke@gmail.com" },
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

            //String calendarId = "primary";
            EventsResource.InsertRequest request = service.Events.Insert(newEvent, calendarID);
            Event createdEvent = request.Execute();
            string link = createdEvent.HtmlLink;
            return "Event Created " + link;
            //Add an event.
            /*Event appointment = new Event();

            //Start time.
            EventDateTime apptStart = new EventDateTime();
            apptStart.DateTime = appt;
            appointment.Start = apptStart;

            //End time.
            EventDateTime apptEnd = new EventDateTime();
            apptEnd.DateTime = appt.AddHours(1);
            appointment.End = apptEnd;

            //Location and description.
            appointment.Location = "The fake hospital";
            appointment.Description = "Dealing with your foot fungus"; // need patient symptoms here.

            // Set attendees.
            appointment.Attendees = new List<EventAttendee>();
            var p = new EventAttendee()
            {
                DisplayName = patient.GiveName(),
                Email = "fake_patient@gmail.com",
                Organizer = false,
                Resource = false,
            };
            appointment.Attendees.Add(p);
            var dr = new EventAttendee()
            {
                DisplayName = doctor.GiveName(),
                Email = "fake_doctor@gmail.com",
                Organizer = false,
                Resource = false,
            };
            appointment.Attendees.Add(dr);
            EventsResource.InsertRequest request = service.Events.Insert(appointment, calendarID);
            Event createdEvent = request.Execute();
            string link = createdEvent.HtmlLink;
            return "Event Created " + link;
            //Console.WriteLine("Event created: {0}", createdEvent.HtmlLink);*/
        }

    }
}