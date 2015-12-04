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
        static string CalendarID = "n8jhsq7f2jft4i4kpifle3g650 @group.calendar.google.com";

        private static UserCredential Login()
        {
            UserCredential credential;

            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/calendar-dotnet-quickstart");

                //credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets{ClientId = "PUT_CLIENT_ID_HERE", ClientSecret = "PUT_CLIENT_SECRETS_HERE"},
                //                new[] { BooksService.Scope.Books }, "user", CancellationToken.None, new FileDataStore(credPath, true));

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", CancellationToken.None, new FileDataStore(credPath, true)).Result;
                //Console.WriteLine("Credential file saved to: " + credPath);
            }

            return credential;
        }

        public void GetEvents()
        {
            UserCredential credential = Login();

            GetEventData(credential);
        }

        public string AddAppointment(DateTime appt, Patient p, Doctor dr)
        {
            UserCredential credential = Login();
            string confirmation = AddEvent(appt, p, dr, credential);
            return confirmation;
        }


        private void GetEventData(UserCredential credential)
        {
            // Create Google Calendar API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List(CalendarID);
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
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            //Add an event.
            Event appointment = new Event();

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
            EventsResource.InsertRequest request = service.Events.Insert(appointment, CalendarID);
            Event createdEvent = request.Execute();
            string link = createdEvent.HtmlLink;
            return "Event Created " + link;
            //Console.WriteLine("Event created: {0}", createdEvent.HtmlLink);
        }

        private void showInfo()
        {
            ;
        }

    }
}

﻿//using Google.Apis.Auth.OAuth2;
//using Google.Apis.Calendar.v3;
//using Google.Apis.Calendar.v3.Data;
//using Google.Apis.Services;
//using Google.Apis.Util.Store;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Hospital
//{
//    public class Calendar
//    {
//        static string[] Scopes = { CalendarService.Scope.Calendar };
//        static string ApplicationName = "Google Calendar Hospital API";
//        static string CalendarID = "chad.hilke@gmail.com";

//        private UserCredential Login()
//        {
//            UserCredential credential;

//            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
//            {
//                string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
//                credPath = Path.Combine(credPath, ".credentials/calendar-dotnet-quickstart");

//                //credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets{ClientId = "PUT_CLIENT_ID_HERE", ClientSecret = "PUT_CLIENT_SECRETS_HERE"},
//                //                new[] { BooksService.Scope.Books }, "user", CancellationToken.None, new FileDataStore(credPath, true));

//                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", CancellationToken.None, new FileDataStore(credPath, true)).Result;
//                //Console.WriteLine("Credential file saved to: " + credPath);
//            }

//            return credential;
//        }

//        public string GetEvents()
//        {
//            UserCredential credential = Login();

//            GetEventData(credential);
//        }


//        private void GetEventData(UserCredential credential)
//        {
//            // Create Google Calendar API service.
//            var service = new CalendarService(new BaseClientService.Initializer()
//            {
//                HttpClientInitializer = credential,
//                ApplicationName = ApplicationName,
//            });

//            // Define parameters of request.
//            EventsResource.ListRequest request = service.Events.List(CalendarID);
//            request.TimeMin = DateTime.Now;
//            request.ShowDeleted = false;
//            request.SingleEvents = true;
//            request.MaxResults = 10;
//            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

//            // List events.
//            Console.WriteLine("Upcoming events:");
//            Events events = request.Execute();
//            if (events.Items.Count > 0)
//            {
//                foreach (var eventItem in events.Items)
//                {
//                    string when = eventItem.Start.DateTime.ToString();
//                    if (String.IsNullOrEmpty(when))
//                    {
//                        when = eventItem.Start.Date;
//                    }
//                    Console.WriteLine("{0} ({1})", eventItem.Summary, when);
//                }
//            }
//            else
//            {
//                Console.WriteLine("No upcoming events found.");
//            }
//            Console.Read();
//        }

//        private void addAppointment(DateTime appt, Patient patient, Doctor doctor)
//        {
//            // Create Google Calendar API service.
//            var service = new CalendarService(new BaseClientService.Initializer()
//            {
//                HttpClientInitializer = credential,
//                ApplicationName = ApplicationName,
//            });

//            //Add an event.
//            Event appointment = new Event();
//            appointment.setSummary("Medical appointment");
//            appointment.setLocation("The fake hospital");
//            appointment.setDescription("Dealing with your foot fungus"); // need patient symptoms here.

//            //Start time.
//            EventDateTime start = new EventDateTime();
//            start.setDateTime(appt);
//            start.setTimeZone("America/Chicago");
//            appointment.setStart(start);

//            //End time.
//            apptEndTime = appt.AddHours(1);
//            EventDateTime end = new EventDateTime();
//            end.setDateTime(apptEndTime);
//            end.setTimeZone("America/Chicago");
//            appointment.setEnd(end);

//            //Recurrence = new String[] { "RRULE:FREQ=WEEKLY;BYDAY=MO" }

//            // Set attendees.
//            EventAttendee pt = new EventAttendee();
//            pt.DisplayName = patient.get(Name);
//            pt.Email = "fake_patient@gmail.com";
//            pt.Organizer = false;
//            pt.Resource = false;
//            EventAttendee dr = new EventAttendee();
//            dr.DisplayName = doctor.get(Name);
//            dr.Email = "fake_doctor@gmail.com";
//            dr.Organizer = false;
//            dr.Resource = false;

//            IList<EventAttendee> lstOfAtendee = new List<EventAttendee>();
//            lstOfAttendee.Add(pt);
//            lstOfAttendee.Add(dr);
//            appointment.Attendees = lstOfAttendee;

//            EventsResource er = new EventsResource(Calendar_Service);

//            Event erinsersted = er.Insert(appointment, ddlCalendars.SelectedValue.ToString()).Fetch();

//            //event = service.events().insert(CalendarId, appointment).execute();
//            Console.WriteLine("Event created: %s\n", appointment.getHtmlLink());
//        }

//    }
//}
