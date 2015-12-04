<<<<<<< HEAD
﻿using Google.Apis.Auth.OAuth2;
=======
using Google.Apis.Auth.OAuth2;
>>>>>>> 798d4f024ed09315d7b1ef9977ff8b05e3113c4f
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
            UserCredential credentialObj;

            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                credentialObj = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", CancellationToken.None, new FileDataStore("Books.ListMyLibrary")).Result;
            }

            return credentialObj;
        }

        public void GetEvents()
        {
            UserCredential credentialObj = Login();
            Events events = GetEventData(credentialObj);
            return events;
            /*foreach (var eventItem in events.Items)
            {
                string when = eventItem.Start.DateTime.ToString();
                if (String.IsNullOrEmpty(when))
                {
                    when = eventItem.Start.Date;
                }

                string eventStr = String.Format("{0} ({1})", eventItem.Summary, when);
            }
            return when;*/
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
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = request.Execute();
            if (events.Items.Count > 0)
            {
                return events;
            }
            else
            {
                return null;
            }
        }

        private string AddEvent(DateTime appt, Patient patientObj, Doctor doctorObj, UserCredential credential)
        {
            // Create Google Calendar API service
            CalendarService service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Create Event
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
                    new EventAttendee() { DisplayName = patientObj.GiveName(), Email = patientObj.emailAddress },
                    new EventAttendee() { DisplayName = doctorObj.GiveName(), Email = doctorObj.emailAddress },
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

}