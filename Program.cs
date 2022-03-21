using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BusinessLayerSprint1;
using BusinessObjectLayer;
namespace UILayerSprint1
{
    class Program
    {
        private static int _numberOfAttempts=5;
        static void Main(string[] args)
        {
                        
            while (_numberOfAttempts>0)
            {
                Console.WriteLine("Enter the Username and Password");
                string username = Console.ReadLine();
                string password = Console.ReadLine();
                if (Admin.isValidAdmin(username, password))
                {
                    Console.Clear();
                    try
                    {


                        while (true)
                        {
                            Console.WriteLine("1-Physician Maintenance\n2-Patient maintenance\n3-Appointment maintenance\n4-Drug maintenance\n5-Consultation maintenance");
                            string choice1 = Console.ReadLine();
                            if (choice1 == "1")
                            {
                                while (true)
                                {
                                    Console.Clear(); Console.WriteLine("PYSICIAN MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                    Console.WriteLine("1-New Physician\n2-Existing Physician");
                                    string choice2 = Console.ReadLine();
                                    if (choice2 == "1")
                                    {
                                        Console.Clear(); Console.WriteLine("PYSICIAN MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                        Console.WriteLine("New Physician");
                                        Physician objPhysician1 = new Physician();
                                        objPhysician1.PhysicianId = Hospital.SetPhysicianId();
                                        Console.WriteLine("Enter the First Name");
                                        objPhysician1.PhysicianFirstName = Console.ReadLine();
                                        Console.WriteLine("Enter the Middle Name");
                                        objPhysician1.PhysicianMiddleName = Console.ReadLine();
                                        Console.WriteLine("Enter the Last Name");
                                        objPhysician1.PhysicianLastName = Console.ReadLine();
                                        Console.WriteLine("Enter the Specialities");
                                        objPhysician1.PhysicianSpeciality = Console.ReadLine();
                                        Console.WriteLine("Enter the Highest Qualification");
                                        objPhysician1.PhysicianQualification = Console.ReadLine();
                                        Console.WriteLine("Enter the Phone Number");
                                        objPhysician1.PhysicianPhoneNumber = Convert.ToInt64(Console.ReadLine());
                                        Console.WriteLine("Enter the Email-Id");
                                        objPhysician1.PhysicianEmail = Console.ReadLine();
                                        Console.WriteLine(Hospital.NewPhysician(objPhysician1));
                                        Console.Clear();
                                        Console.WriteLine("PYSICIAN MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                        Console.WriteLine("New Physician"); Console.WriteLine(); Console.WriteLine();
                                        Physician objPhysician = Hospital.FetchPhysicianById(objPhysician1.PhysicianId);
                                        Console.WriteLine("Physician Id: " + objPhysician.PhysicianId);
                                        Console.WriteLine("Name: " + objPhysician.PhysicianFirstName + " " + objPhysician.PhysicianMiddleName + " " + objPhysician.PhysicianLastName);
                                        Console.WriteLine("Specialities: " + objPhysician.PhysicianSpeciality);
                                        Console.WriteLine("Highest Qualification: " + objPhysician.PhysicianQualification);
                                        Console.WriteLine("Phone Number: " + objPhysician.PhysicianPhoneNumber);
                                        Console.WriteLine("Email-Id: " + objPhysician.PhysicianEmail);

                                        break;
                                    }

                                    else if (choice2 == "2")
                                    {
                                        while (true)
                                        {
                                            Console.Clear(); Console.WriteLine("PYSICIAN MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                            Console.WriteLine("Existing Physician");
                                            Console.WriteLine("How may we help you: "); Console.WriteLine(); Console.WriteLine();
                                            Console.WriteLine("1: Fetch Physician's Details by Id");
                                            Console.WriteLine("2: Fetch all the Physician's Details");
                                            Console.WriteLine("3: Delete a Physician's Record");
                                            Console.WriteLine("4: Update a Physician's Details");
                                            string choice3 = Console.ReadLine();
                                            if (choice3 == "1")
                                            {
                                                Console.Clear(); Console.WriteLine("PYSICIAN MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                                Console.WriteLine("Fetching Physician's Details by Id");
                                                Console.WriteLine("Enter the Physician's Id");
                                                string phyId1 = Console.ReadLine();
                                                Physician objPhysician2 = Hospital.FetchPhysicianById(phyId1);
                                                Console.WriteLine("Physician Id: " + objPhysician2.PhysicianId);
                                                Console.WriteLine("Name: " + objPhysician2.PhysicianFirstName + " " + objPhysician2.PhysicianMiddleName + " " + objPhysician2.PhysicianLastName);
                                                Console.WriteLine("Specialities: " + objPhysician2.PhysicianSpeciality);
                                                Console.WriteLine("Highest Qualification: " + objPhysician2.PhysicianQualification);
                                                Console.WriteLine("Phone Number: " + objPhysician2.PhysicianPhoneNumber);
                                                Console.WriteLine("Email-Id: " + objPhysician2.PhysicianEmail);
                                                break;
                                            }

                                            else if (choice3 == "2")
                                            {
                                                Console.Clear(); Console.WriteLine("PYSICIAN MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                                Console.WriteLine("Fetching all the Physician's Details");
                                                List<Physician> physiciansList = Hospital.FetchAllPhysicians();
                                                foreach (Physician physician in physiciansList)
                                                {
                                                    Console.WriteLine("Physician Id: " + physician.PhysicianId);
                                                    Console.WriteLine("Name: " + physician.PhysicianFirstName + " " + physician.PhysicianMiddleName + " " + physician.PhysicianLastName);
                                                    Console.WriteLine("Specialities: " + physician.PhysicianSpeciality);
                                                    Console.WriteLine("Highest Qualification: " + physician.PhysicianQualification);
                                                    Console.WriteLine("Phone Number: " + physician.PhysicianPhoneNumber);
                                                    Console.WriteLine("Email-Id: " + physician.PhysicianEmail);
                                                    Console.WriteLine();
                                                }
                                                break;
                                            }
                                            else if (choice3 == "3")
                                            {
                                                Console.Clear(); Console.WriteLine("PYSICIAN MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                                Console.WriteLine("Deleting Physician's record");
                                                Console.WriteLine("Enter the Physician's Id to be deleted");
                                                string phyId2 = Console.ReadLine();
                                                Hospital.DeletePhysician(phyId2);
                                                break;
                                            }
                                            else if (choice3 == "4")
                                            {
                                                Console.Clear(); Console.WriteLine("PYSICIAN MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                                Console.WriteLine("Updating Physician's Details");
                                                Console.WriteLine("Enter the Physician's Id");
                                                string phyId3 = Console.ReadLine();
                                                while (true)
                                                {
                                                    Console.Clear();
                                                    Console.Clear(); Console.WriteLine("PYSICIAN MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                                    Console.WriteLine("Updating Physician's Details");
                                                    Console.WriteLine("1:Update Physician's Name");
                                                    Console.WriteLine("2:Update Physician's Phone Number");
                                                    Console.WriteLine("3:Update Physician's Specialities");
                                                    Console.WriteLine("4:Update Physician's Highest Qualification");
                                                    Console.WriteLine("5:Update Physician's Email-Id");
                                                    string choice4 = Console.ReadLine();
                                                    if (choice4 == "1")
                                                    {
                                                        Console.Write("New First Name");
                                                        string phyFirstName = Console.ReadLine();
                                                        Console.WriteLine("New Second Name");
                                                        string phyMiddleName = Console.ReadLine();
                                                        Console.WriteLine("New Last Name");
                                                        string phyLastName = Console.ReadLine();
                                                        Hospital.ModifyPatientFirstName(phyId3, phyFirstName);
                                                        Hospital.ModifyPatientMiddleName(phyId3, phyMiddleName);
                                                        Hospital.ModifyPatientLastName(phyId3, phyLastName);
                                                        break;
                                                    }
                                                    else if (choice4 == "2")
                                                    {
                                                        Console.WriteLine("Enter the new Phone Number");
                                                        string phyPN = Console.ReadLine();
                                                        long newPN = Convert.ToInt64(phyPN);
                                                        Hospital.ModifyPhysicianPhoneNumber(phyId3, newPN);
                                                        break;
                                                    }
                                                    else if (choice4 == "3")
                                                    {
                                                        Console.WriteLine("Enter the Specialities to be Updated");
                                                        string phySpeciality = Console.ReadLine();
                                                        Hospital.ModifyPhysicianSpeciality(phyId3, phySpeciality);
                                                        break;
                                                    }
                                                    else if (choice4 == "4")
                                                    {
                                                        Console.WriteLine("Enter the New Highest Qualification");
                                                        string phyQualification = Console.ReadLine();
                                                        Hospital.ModifyPhysicianQualification(phyId3, phyQualification);
                                                        break;
                                                    }
                                                    else if (choice4 == "5")
                                                    {
                                                        Console.WriteLine("Enter your new Email");
                                                        string phyEmail = Console.ReadLine();
                                                        Hospital.ModifyPhysicianEmail(phyId3, phyEmail);
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Invalid Choice");
                                                    }


                                                }
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid Choice");

                                            }
                                            break;
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Choice");
                                    }                                           

                                    
                                }
                                break;                             
                            }

                            else if (choice1 == "2")
                            {
                                while (true)
                                {
                                    Console.Clear(); Console.WriteLine("PATIENT MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                    Console.WriteLine("1-New Physician\n2-Existing Physician");
                                    string choice2 = Console.ReadLine();
                                    if (choice2 == "1")
                                    {
                                        Console.Clear(); Console.WriteLine("PATIENT MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                        Console.WriteLine("New Patient");
                                        Patient objPatient1 = new Patient();
                                        Address objAddress1 = new Address();
                                        objPatient1.PatientId = Hospital.SetPatientId();
                                        objAddress1.AddressCode = Hospital.SetAddressCode();
                                        objPatient1.PatientAddressCode = objAddress1.AddressCode;
                                        Console.WriteLine("Enter the First Name");
                                        objPatient1.PatientFirstName = Console.ReadLine();
                                        Console.WriteLine("Enter the Middle Name");
                                        objPatient1.PatientMiddleName = Console.ReadLine();
                                        Console.WriteLine("Enter the Last Name");
                                        objPatient1.PatientLastName = Console.ReadLine();
                                        Console.WriteLine("Enter Patient's Date Of Birth in the format of YYYY-MM-DD");
                                        string dob = Console.ReadLine();
                                        objPatient1.PatientDOB = Convert.ToDateTime(dob);
                                        Console.WriteLine("Enter Patient's BMI");
                                        objPatient1.PatientBMI = (float)Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("Is Patient Diabetic. 1:true  2:false");
                                        string patDiabetic = Console.ReadLine();
                                        bool isDiabetic;
                                        if (patDiabetic.Equals("true", StringComparison.OrdinalIgnoreCase)) { isDiabetic = true; } else { isDiabetic = false; }
                                        objPatient1.IsDiabeticPatient = isDiabetic;
                                        Console.WriteLine("Enter Patient's Medical History");
                                        objPatient1.PatientMedicalHistory = Console.ReadLine();
                                        Console.WriteLine("Enter Patient's Phone Number");
                                        objPatient1.PatientPhoneNumber = Convert.ToInt64(Console.ReadLine());
                                        Console.WriteLine("Enter the House No.");
                                        objAddress1.AddressLine1 = Console.ReadLine();
                                        Console.WriteLine("Enter the AddressLine");
                                        objAddress1.AddressLine2 = Console.ReadLine();
                                        Console.WriteLine("Enter the LandMark");
                                        objAddress1.LandMark = Console.ReadLine();
                                        Console.WriteLine("Enter the City Name");
                                        objAddress1.City = Console.ReadLine();
                                        Console.WriteLine("Enter the PinCode");
                                        objAddress1.PinCode = Convert.ToInt64(Console.ReadLine());
                                        Console.WriteLine("Enter the State");
                                        objAddress1.State = Console.ReadLine();
                                        Console.WriteLine("Enter the Country");
                                        objAddress1.Country = Console.ReadLine();

                                        Console.WriteLine(Hospital.SaveAddress(objAddress1));
                                        Console.WriteLine(Hospital.NewPatient(objPatient1));
                                        Console.Clear();
                                        Console.WriteLine("PATIENT MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                        Console.WriteLine("New Patient"); Console.WriteLine(); Console.WriteLine();
                                        Patient objPatient = Hospital.FetchPatientById(objPatient1.PatientId);
                                        Address objAddress = Hospital.FetchAddress(objAddress1.AddressCode);
                                        Console.WriteLine("Patient Id: " + objPatient.PatientId);
                                        Console.WriteLine("Name: " + objPatient.PatientFirstName + " " + objPatient.PatientMiddleName + " " + objPatient.PatientLastName);
                                        Console.WriteLine("Date Of Birth: " + objPatient.PatientDOB.Date);
                                        Console.WriteLine("Body Mass Index: " + objPatient.PatientBMI);
                                        Console.WriteLine("IsDiabetic: " + objPatient.IsDiabeticPatient);
                                        Console.WriteLine("Medical  History: " + objPatient.PatientMedicalHistory);
                                        Console.WriteLine("Phone Number: " + objPatient.PatientPhoneNumber);
                                        Console.WriteLine("Address--------");
                                        Console.WriteLine("Address Code: " + objAddress.AddressCode);
                                        Console.WriteLine("House No." + objAddress.AddressLine1);
                                        Console.WriteLine("AddressLine: " + objAddress.AddressLine2);
                                        Console.WriteLine("Address LandMark: " + objAddress.LandMark);
                                        Console.WriteLine("Address City Name: " + objAddress.City);
                                        Console.WriteLine("Address PineCode: " + objAddress.PinCode);
                                        Console.WriteLine("Address State: " + objAddress.State);
                                        Console.WriteLine("Address Country: " + objAddress.Country); Console.WriteLine(); Console.WriteLine();
                                        Console.WriteLine("Type 'Yes' to go to the Appointment Section");
                                        string yes = Console.ReadLine();
                                        if (yes.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                                        {
                                            Console.Clear(); Console.WriteLine("PATIENT MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                            Console.WriteLine("Appointment Section");
                                            Appointment objAppointment1 = new Appointment();
                                            Console.WriteLine("Enter the Preferred Doctor's Id");
                                            string doctId = Console.ReadLine();
                                            Console.WriteLine("Do u wish to pay now or later-  Press 'Now' or 'Later'");
                                            string feeStatus = Console.ReadLine();
                                            if (feeStatus.Equals("Now", StringComparison.OrdinalIgnoreCase))
                                            {
                                                feeStatus = "Paid";
                                            }
                                            else
                                            {
                                                feeStatus = "UnPaid";
                                            }
                                            objAppointment1.BookingId = Hospital.SetBookingId();
                                            objAppointment1.BookingDateAndTime = DateTime.Now;
                                            objAppointment1.AppointmentDateAndTime = DateTime.Now.AddDays(Hospital.GiveAppointmentDate()).AddDays(Hospital.GiveAppointmentTime());
                                            objAppointment1.AppointedPatient = objPatient.PatientId;
                                            objAppointment1.PreferredDoctor = doctId;
                                            objAppointment1.ConsultationFee = Hospital.GetConsultationFee();
                                            objAppointment1.FeeStatus = feeStatus;
                                            objAppointment1.AppointmentStatus = "Pending";
                                            Console.WriteLine(Hospital.FixAppointment(objAppointment1));
                                            Console.Clear();
                                            Console.WriteLine("PATIENT MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                            Console.WriteLine("New Patient"); Console.WriteLine(); Console.WriteLine();
                                            Appointment objAppointment = Hospital.FetchAppointmentDetails(objAppointment1.BookingId);
                                            Console.WriteLine("Appointment Booking Id: " + objAppointment.BookingId);
                                            Console.WriteLine("Booking Date: " + objAppointment.BookingDateAndTime.Date);
                                            Console.WriteLine("Booking Time: " + objAppointment.BookingDateAndTime.TimeOfDay);
                                            Console.WriteLine("Appointment Date: " + objAppointment.AppointmentDateAndTime.Date);
                                            Console.WriteLine("Appointment Time: " + objAppointment.AppointmentDateAndTime.TimeOfDay);
                                            Console.WriteLine("Appointed Patient Id: " + objAppointment.AppointedPatient);
                                            Console.WriteLine("Preferred Doctor Id: " + objAppointment.PreferredDoctor);
                                            Console.WriteLine("Consultation Fee" + objAppointment.ConsultationFee);
                                            Console.WriteLine("Fee Status: " + objAppointment.FeeStatus);
                                            Console.WriteLine("Appointment Status: " + objAppointment.AppointmentStatus);
                                        }
                                        else
                                        {
                                            Console.WriteLine("You chose not to Book Appointment.");
                                        }

                                        break;
                                    }
                                    else if (choice2 == "2")
                                    {
                                        while (true)
                                        {
                                            Console.Clear(); Console.WriteLine("PATIENT MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                            Console.WriteLine("Existing Patient");
                                            Console.WriteLine("How may we help you: "); Console.WriteLine(); Console.WriteLine();
                                            Console.WriteLine("1: Fetch Patient's Details by Id");
                                            Console.WriteLine("2: Fetch Patient's Details by Phone Number");
                                            Console.WriteLine("3: Fetch all the Patient's Details");
                                            Console.WriteLine("4: Delete a Patient's Record");
                                            Console.WriteLine("5: Update a Patient's Details");
                                            string choice3 = Console.ReadLine();
                                            if (choice3 == "1")
                                            {
                                                Console.Clear(); Console.WriteLine("PATIENT MAINTAINANCE\r\r"); Console.WriteLine(); Console.WriteLine();
                                                Console.WriteLine("Fetching Patient's Details by Id");
                                                Console.WriteLine("Enter the Patient's Id");
                                                string patId1 = Console.ReadLine();
                                                Patient objPatient2 = Hospital.FetchPatientById(patId1);
                                                Address objAddress2 = Hospital.FetchAddress(objPatient2.PatientAddressCode);
                                                Console.WriteLine("Patient Id: " + objPatient2.PatientId);
                                                Console.WriteLine("Name: " + objPatient2.PatientFirstName + " " + objPatient2.PatientMiddleName + " " + objPatient2.PatientLastName);
                                                Console.WriteLine("Date Of Birth: " + objPatient2.PatientDOB.Date);
                                                Console.WriteLine("Body Mass Index: " + objPatient2.PatientBMI);
                                                Console.WriteLine("IsDiabetic: " + objPatient2.IsDiabeticPatient);
                                                Console.WriteLine("Medical  History: " + objPatient2.PatientMedicalHistory);
                                                Console.WriteLine("Phone Number: " + objPatient2.PatientPhoneNumber);
                                                Console.WriteLine("Address--------");
                                                Console.WriteLine("Address Code: " + objAddress2.AddressCode);
                                                Console.WriteLine("House No." + objAddress2.AddressLine1);
                                                Console.WriteLine("AddressLine: " + objAddress2.AddressLine2);
                                                Console.WriteLine("Address LandMark: " + objAddress2.LandMark);
                                                Console.WriteLine("Address City Name: " + objAddress2.City);
                                                Console.WriteLine("Address PineCode: " + objAddress2.PinCode);
                                                Console.WriteLine("Address State: " + objAddress2.State);
                                                Console.WriteLine("Address Country: " + objAddress2.Country);
                                                break;
                                            }
                                            else if (choice3 == "2")
                                            {
                                                Console.Clear(); Console.WriteLine("PATIENT MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                                Console.WriteLine("Fetching the Patient's Details by Phone Number");
                                                Console.WriteLine("Enter the Phone Number");
                                                long patPN = Convert.ToInt64(Console.ReadLine());
                                                List<Patient> patientsList = Hospital.FetchPatientsByPhoneNumber(patPN);
                                                foreach (Patient patient in patientsList)
                                                {
                                                    Console.WriteLine("Patient Id: " + patient.PatientId);
                                                    Console.WriteLine("Name: " + patient.PatientFirstName + " " + patient.PatientMiddleName + " " + patient.PatientLastName);
                                                    Console.WriteLine("Date Of Birth: " + patient.PatientDOB.Date);
                                                    Console.WriteLine("Body Mass Index: " + patient.PatientBMI);
                                                    Console.WriteLine("IsDiabetic: " + patient.IsDiabeticPatient);
                                                    Console.WriteLine("Medical  History: " + patient.PatientMedicalHistory);
                                                    Console.WriteLine("Phone Number: " + patient.PatientPhoneNumber);
                                                    Console.WriteLine("Address--------");
                                                    Address patientAddress = Hospital.FetchAddress(patient.PatientAddressCode);
                                                    Console.WriteLine("Address Code: " + patientAddress.AddressCode);
                                                    Console.WriteLine("House No." + patientAddress.AddressLine1);
                                                    Console.WriteLine("AddressLine: " + patientAddress.AddressLine2);
                                                    Console.WriteLine("Address LandMark: " + patientAddress.LandMark);
                                                    Console.WriteLine("Address City Name: " + patientAddress.City);
                                                    Console.WriteLine("Address PineCode: " + patientAddress.PinCode);
                                                    Console.WriteLine("Address State: " + patientAddress.State);
                                                    Console.WriteLine("Address Country: " + patientAddress.Country);
                                                    Console.WriteLine();
                                                }
                                                break;
                                            }
                                            else if (choice3 == "3")
                                            {
                                                Console.Clear(); Console.WriteLine("PATIENT MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                                Console.WriteLine("Fetching all the Patient's Details");
                                                List<Patient> patientsList = Hospital.FetchAllPatients();
                                                foreach (Patient patient in patientsList)
                                                {
                                                    Console.WriteLine("Patient Id: " + patient.PatientId);
                                                    Console.WriteLine("Name: " + patient.PatientFirstName + " " + patient.PatientMiddleName + " " + patient.PatientLastName);
                                                    Console.WriteLine("Date Of Birth: " + patient.PatientDOB.Date);
                                                    Console.WriteLine("Body Mass Index: " + patient.PatientBMI);
                                                    Console.WriteLine("IsDiabetic: " + patient.IsDiabeticPatient);
                                                    Console.WriteLine("Medical  History: " + patient.PatientMedicalHistory);
                                                    Console.WriteLine("Phone Number: " + patient.PatientPhoneNumber);
                                                    Console.WriteLine("Address--------");
                                                    Address patientAddress = Hospital.FetchAddress(patient.PatientAddressCode);
                                                    Console.WriteLine("Address Code: " + patientAddress.AddressCode);
                                                    Console.WriteLine("House No." + patientAddress.AddressLine1);
                                                    Console.WriteLine("AddressLine: " + patientAddress.AddressLine2);
                                                    Console.WriteLine("Address LandMark: " + patientAddress.LandMark);
                                                    Console.WriteLine("Address City Name: " + patientAddress.City);
                                                    Console.WriteLine("Address PineCode: " + patientAddress.PinCode);
                                                    Console.WriteLine("Address State: " + patientAddress.State);
                                                    Console.WriteLine("Address Country: " + patientAddress.Country);
                                                    Console.WriteLine();
                                                }
                                                break;
                                            }
                                            else if (choice3 == "4")
                                            {
                                                Console.Clear(); Console.WriteLine("PATIENT MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                                Console.WriteLine("Deleting Patient's record");
                                                Console.WriteLine("Enter the Patient's Id to be deleted");
                                                string patId2 = Console.ReadLine();
                                                Console.WriteLine(Hospital.DeletePatient(patId2));
                                                break;
                                            }
                                            else if (choice3 == "5")
                                            {
                                                Console.Clear(); Console.WriteLine("PATIENT MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                                Console.WriteLine("Updating Patient's Details");
                                                Console.WriteLine("Enter the Patient's Id");
                                                string patId3 = Console.ReadLine();
                                                while (true)
                                                {
                                                    Console.Clear();
                                                    Console.Clear(); Console.WriteLine("PYSICIAN MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                                    Console.WriteLine("Updating Physician's Details");
                                                    Console.WriteLine("1:Update Patient's Name");
                                                    Console.WriteLine("2:Update Patient's DOB");
                                                    Console.WriteLine("3:Update Patient's BMI");
                                                    Console.WriteLine("4:Update Patient's Diabeties Status");
                                                    Console.WriteLine("5:Update Patient's Medical History");
                                                    Console.WriteLine("6:Update Patient's Phone Number");
                                                    Console.WriteLine("7:Update Patient's Address");
                                                    string choice4 = Console.ReadLine();
                                                    if (choice4 == "1")
                                                    {
                                                        Console.Write("New First Name");
                                                        string patFirstName = Console.ReadLine();
                                                        Console.WriteLine("New Second Name");
                                                        string patMiddleName = Console.ReadLine();
                                                        Console.WriteLine("New Last Name");
                                                        string patLastName = Console.ReadLine();
                                                        Hospital.ModifyPatientFirstName(patId3, patFirstName);
                                                        Hospital.ModifyPatientMiddleName(patId3, patMiddleName);
                                                        Hospital.ModifyPatientLastName(patId3, patLastName);
                                                        Console.WriteLine("Name Updated");
                                                        break;
                                                    }
                                                    else if (choice4 == "2")
                                                    {
                                                        Console.WriteLine("Enter the new DOB in the format: YYYY-MM-DD");
                                                        string patDOB = Console.ReadLine();
                                                        DateTime newDOB = Convert.ToDateTime(patDOB);
                                                        Console.WriteLine(Hospital.ModifyPatientDOB(patId3, newDOB));
                                                        break;
                                                    }
                                                    else if (choice4 == "3")
                                                    {
                                                        Console.WriteLine("Enter the new BMI");
                                                        float patBMI = (float)Convert.ToDouble(Console.ReadLine());
                                                        Console.WriteLine(Hospital.ModifyPatientBMI(patId3, patBMI));
                                                        break;
                                                    }
                                                    else if (choice4 == "4")
                                                    {
                                                        Console.WriteLine("Is Patient Diabetic. 1:true  2:false");
                                                        string patD = Console.ReadLine();
                                                        bool isD;
                                                        if (patD.Equals("true", StringComparison.OrdinalIgnoreCase)) { isD = true; } else { isD = false; }
                                                        Console.WriteLine(Hospital.ModifyPatientIsDiabetic(patId3, isD));
                                                        break;
                                                    }
                                                    else if (choice4 == "5")
                                                    {
                                                        Console.WriteLine("Enter Patient's Full Medical History");
                                                        string patMH = Console.ReadLine();
                                                        Console.WriteLine(Hospital.ModifyPatientMedicalHistory(patId3, patMH));
                                                        break;
                                                    }
                                                    else if (choice4 == "6")
                                                    {
                                                        Console.WriteLine("Enter the Patient's Phone Number");
                                                        long patPN = Convert.ToInt64(Console.ReadLine());
                                                        Console.WriteLine(Hospital.ModifyPatientPhoneNumber(patId3, patPN));
                                                        break;
                                                    }
                                                    else if (choice4 == "7")
                                                    {
                                                        Address objAddress3 = new Address();
                                                        objAddress3.AddressCode = Hospital.SetAddressCode();
                                                        Console.WriteLine("Enter the House No.");
                                                        objAddress3.AddressLine1 = Console.ReadLine();
                                                        Console.WriteLine("Enter the AddressLine");
                                                        objAddress3.AddressLine2 = Console.ReadLine();
                                                        Console.WriteLine("Enter the LandMark");
                                                        objAddress3.LandMark = Console.ReadLine();
                                                        Console.WriteLine("Enter the City Name");
                                                        objAddress3.City = Console.ReadLine();
                                                        Console.WriteLine("Enter the PinCode");
                                                        objAddress3.PinCode = Convert.ToInt64(Console.ReadLine());
                                                        Console.WriteLine("Enter the State");
                                                        objAddress3.State = Console.ReadLine();
                                                        Console.WriteLine("Enter the Country");
                                                        objAddress3.Country = Console.ReadLine();
                                                        Hospital.SaveAddress(objAddress3);
                                                        Console.WriteLine(Hospital.ModifyPatientAddress(patId3, Hospital.FetchAddress(objAddress3.AddressCode).AddressCode));
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Invalid Choice");

                                                    }
                                                }
                                                break;
                                            }

                                            else
                                            {
                                                Console.WriteLine("Invalid Choice");
                                            }

                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Choice");
                                    }                                          
                                    
                                }
                                break;
                               
                            }

                            else if (choice1 == "3")
                            {
                                while (true)
                                {   Console.Clear(); Console.WriteLine("APPOINTMENT MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();

                                    Console.WriteLine("How may we help you: "); Console.WriteLine(); Console.WriteLine();
                                    Console.WriteLine("1: Fetch Appointment Details by BookingID");
                                    Console.WriteLine("2: Fetch All Appointment Details");
                                    Console.WriteLine("3: Cancel Appointment");
                                    Console.WriteLine("4: Update All Appointment Status");
                                    string choice4 = Console.ReadLine();
                                    if (choice4 == "1")
                                    {
                                        Console.Clear(); Console.WriteLine("APPOINTMENT MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                        Console.WriteLine("Fetching Appointment Details by BookingId");
                                        Console.WriteLine("Enter the Booking Id");
                                        string appId1 = Console.ReadLine();
                                        Appointment objAppointment2 = Hospital.FetchAppointmentDetails(appId1);
                                        Console.WriteLine("Appointment Booking Id: " + objAppointment2.BookingId);
                                        Console.WriteLine("Booking Date: " + objAppointment2.BookingDateAndTime.Date);
                                        Console.WriteLine("Booking Time: " + objAppointment2.BookingDateAndTime.TimeOfDay);
                                        Console.WriteLine("Appointment Date: " + objAppointment2.AppointmentDateAndTime.Date);
                                        Console.WriteLine("Appointment Time: " + objAppointment2.AppointmentDateAndTime.TimeOfDay);
                                        Console.WriteLine("Appointed Patient Id: " + objAppointment2.AppointedPatient);
                                        Console.WriteLine("Preferred Doctor Id: " + objAppointment2.PreferredDoctor);
                                        Console.WriteLine("Consultation Fee" + objAppointment2.ConsultationFee);
                                        Console.WriteLine("Fee Status: " + objAppointment2.FeeStatus);
                                        Console.WriteLine("Appointment Status: " + objAppointment2.AppointmentStatus);
                                        break;
                                    }

                                    else if (choice4 == "2")
                                    {
                                        Console.Clear(); Console.WriteLine("APPOINTMENT MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                        Console.WriteLine("Fetching all the Appointment Details");
                                        List<Appointment> appointmentList = Hospital.FetchAllAppointmentDetails();
                                        foreach (Appointment appointment in appointmentList)
                                        {
                                            Console.WriteLine("Appointment Booking Id: " + appointment.BookingId);
                                            Console.WriteLine("Booking Date: " + appointment.BookingDateAndTime.Date);
                                            Console.WriteLine("Booking Time: " + appointment.BookingDateAndTime.TimeOfDay);
                                            Console.WriteLine("Appointment Date: " + appointment.AppointmentDateAndTime.Date);
                                            Console.WriteLine("Appointment Time: " + appointment.AppointmentDateAndTime.TimeOfDay);
                                            Console.WriteLine("Appointed Patient Id: " + appointment.AppointedPatient);
                                            Console.WriteLine("Preferred Doctor Id: " + appointment.PreferredDoctor);
                                            Console.WriteLine("Consultation Fee" + appointment.ConsultationFee);
                                            Console.WriteLine("Fee Status: " + appointment.FeeStatus);
                                            Console.WriteLine("Appointment Status: " + appointment.AppointmentStatus);
                                            Console.WriteLine();
                                        }
                                        break;
                                    }
                                    else if (choice4 == "3")
                                    {
                                        Console.Clear(); Console.WriteLine("APPOINTMENT MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                        Console.WriteLine(" Cancel Appointment");
                                        Console.WriteLine("Enter the BookingId to be cancelled");
                                        string appId2 = Console.ReadLine();
                                        Console.WriteLine(Hospital.CancelAppointment(appId2));
                                        break;
                                    }
                                    else if (choice4 == "4")
                                    {
                                        Console.Clear(); Console.WriteLine("APPOINTMENT MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                        Console.WriteLine("Update all Appointment Status");
                                        Console.WriteLine(Hospital.UpdateAllAppointmentStatus());
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Choice");
                                    }
                                   
                                }
                                break;
                            }

                            else if (choice1 == "4")
                            {
                                while (true)
                                {
                                    Console.Clear(); Console.WriteLine("DRUG MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                    Console.WriteLine("1-New Drug\n2-Existing Drug");
                                    string choice2 = Console.ReadLine();
                                    if (choice2 == "1")
                                    {
                                        Console.Clear(); Console.WriteLine("DRUG MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                        Console.WriteLine("New Drug");
                                        Drug objDrug1 = new Drug();
                                        objDrug1.DrugId = Hospital.SetDrugId();
                                        Console.WriteLine("Enter the Drug Name");
                                        objDrug1.DrugName = Console.ReadLine();
                                        Console.WriteLine("Enter the Brand Name");
                                        objDrug1.BrandName = Console.ReadLine();
                                        Console.WriteLine("Enter the MRP");
                                        objDrug1.MRP = (float)Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("Enter the Manufactoring Date in the format : YYYY-MM-DD");
                                        objDrug1.ManufacturingDate = Convert.ToDateTime(Console.ReadLine());
                                        Console.WriteLine("Enter the Expiry Date in the format : YYYY-MM-DD");
                                        objDrug1.ExpiryDate = Convert.ToDateTime(Console.ReadLine());
                                        Console.WriteLine("Enter the Indications");
                                        objDrug1.Indications = Console.ReadLine();
                                        Console.WriteLine("Enter the Composition");
                                        objDrug1.Composition = Console.ReadLine();
                                        Console.WriteLine("Enter the Batch Number");
                                        objDrug1.BatchNo = Convert.ToInt64(Console.ReadLine());
                                        Console.WriteLine("Enter Drug Dosage Involed");
                                        objDrug1.DrugDosageInvolvedId = Console.ReadLine();
                                        Console.WriteLine("Enter the Drug Dose");
                                        objDrug1.DrugDose = Console.ReadLine();

                                        Console.WriteLine(Hospital.NewDrug(objDrug1));
                                        Console.Clear();
                                        Console.WriteLine("DRUG MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                        Console.WriteLine("New Drug"); Console.WriteLine(); Console.WriteLine();
                                        Drug objDrug = Hospital.FetchDrugById(objDrug1.DrugId);
                                        Console.WriteLine("Drug Id: " + objDrug.DrugId);
                                        Console.WriteLine("Drug Name: " + objDrug.DrugName);
                                        Console.WriteLine("Brand Name: "+ objDrug.BrandName);
                                        Console.WriteLine("MRP: "+objDrug.MRP);
                                        Console.WriteLine("Manufactoring Date: " + objDrug.ManufacturingDate);
                                        Console.WriteLine("Expiry Date: " + objDrug.ExpiryDate);
                                        Console.WriteLine("Indications: " + objDrug.Indications);
                                        Console.WriteLine("Composition: "+objDrug.Composition);
                                        Console.WriteLine("Batch Number: " + objDrug.BatchNo);
                                        Console.WriteLine("Drug Dosage Id: " + objDrug.DrugDosageInvolvedId);
                                        Console.WriteLine("Drug Dose: " + objDrug.DrugDose);

                                 
                                        break;
                                    }
                                    else if (choice2 == "2")
                                    {
                                        while (true)
                                        {
                                            Console.Clear(); Console.WriteLine("DRUG MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                            Console.WriteLine("Existing Drug");
                                            Console.WriteLine("How may we help you: "); Console.WriteLine(); Console.WriteLine();
                                            Console.WriteLine("1: Fetch Drug Details by Id");
                                            Console.WriteLine("2: Fetch All Drugs Details");
                                            Console.WriteLine("3: Update a Drug Price");
                                            Console.WriteLine("4: Delete all the Expired Drugs");
                                            Console.WriteLine("5: Fetch all the Drugs by a DosageId");
                                            string choice3 = Console.ReadLine();
                                            if (choice3 == "1")
                                            {
                                                Console.Clear(); Console.WriteLine("DRUG MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                                Console.WriteLine("Fetching Drug Details by Id");
                                                Console.WriteLine("Enter the Drug Id");
                                                string dgId1 = Console.ReadLine();
                                                Drug objDrug2 = Hospital.FetchDrugById(dgId1);
                                                Console.WriteLine("Drug Id: " + objDrug2.DrugId);
                                                Console.WriteLine("Drug Name: " + objDrug2.DrugName);
                                                Console.WriteLine("Brand Name: " + objDrug2.BrandName);
                                                Console.WriteLine("MRP: " + objDrug2.MRP);
                                                Console.WriteLine("Manufactoring Date: " + objDrug2.ManufacturingDate);
                                                Console.WriteLine("Expiry Name: " + objDrug2.ExpiryDate);
                                                Console.WriteLine("Indications: " + objDrug2.Indications);
                                                Console.WriteLine("Composition: " + objDrug2.Composition);
                                                Console.WriteLine("Batch Number: " + objDrug2.BatchNo);
                                                Console.WriteLine("Drug Dosage Id: " + objDrug2.DrugDosageInvolvedId);
                                                Console.WriteLine("Drug Dose: " + objDrug2.DrugDose);
                                                break;
                                            }

                                            else if (choice3 == "2")
                                            {
                                                Console.Clear(); Console.WriteLine("DRUG MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                                Console.WriteLine("Fetching all the Drugs Details");
                                                List<Drug> drugsList = Hospital.FetchAllDrug();
                                                foreach (Drug drug in drugsList)
                                                {
                                                    Console.WriteLine("Drug Id: " + drug.DrugId);
                                                    Console.WriteLine("Drug Name: " + drug.DrugName);
                                                    Console.WriteLine("Brand Name: " + drug.BrandName);
                                                    Console.WriteLine("MRP: " + drug.MRP);
                                                    Console.WriteLine("Manufactoring Date: " + drug.ManufacturingDate);
                                                    Console.WriteLine("Expiry Name: " + drug.ExpiryDate);
                                                    Console.WriteLine("Indications: " + drug.Indications);
                                                    Console.WriteLine("Composition: " + drug.Composition);
                                                    Console.WriteLine("Batch Number: " + drug.BatchNo);
                                                    Console.WriteLine("Drug Dosage Id: " + drug.DrugDosageInvolvedId);
                                                    Console.WriteLine("Drug Dose: " + drug.DrugDose);
                                                    Console.WriteLine();
                                                }
                                                break;
                                            }
                                            else if (choice3 == "3")
                                            {
                                                Console.Clear(); Console.WriteLine("DRUG MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                                Console.WriteLine("Updating Drug price");
                                                Console.WriteLine("Enter the drug Id to be updated");
                                                string dgId2 = Console.ReadLine();
                                                Console.WriteLine("Enter the New Price");
                                                float newPrice=(float)Convert.ToDouble(Console.ReadLine());
                                                Console.WriteLine(Hospital.UpdatePrice(dgId2,newPrice));
                                                break;
                                            }
                                            else if(choice3 == "4")
                                            {
                                                Console.Clear(); Console.WriteLine("DRUG MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                                Console.WriteLine("Deleting All The Expired Drugs");
                                                Console.WriteLine(Hospital.RemoveExpiredDrugs());
                                                break;
                                            }
                                            else if (choice3 == "5")
                                            {
                                                Console.Clear(); Console.WriteLine("DRUG MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                                Console.WriteLine("Fetching all the Drugs Details by a dosageId");
                                                Console.WriteLine("Enter the DosageId");
                                                string dgeId = Console.ReadLine();
                                                List<Drug> drugsList = Hospital.FetchAllDrugsInDosage(dgeId);
                                                Console.WriteLine("Drugs in the DrugDosage of Id: " + dgeId);Console.WriteLine();Console.WriteLine();
                                                foreach (Drug drug in drugsList)
                                                {
                                                    Console.WriteLine("Drug Id: " + drug.DrugId);
                                                    Console.WriteLine("Drug Name: " + drug.DrugName);
                                                    Console.WriteLine("Brand Name: " + drug.BrandName);
                                                    Console.WriteLine("MRP: " + drug.MRP);
                                                    Console.WriteLine("Manufactoring Date: " + drug.ManufacturingDate);
                                                    Console.WriteLine("Expiry Name: " + drug.ExpiryDate);
                                                    Console.WriteLine("Indications: " + drug.Indications);
                                                    Console.WriteLine("Composition: " + drug.Composition);
                                                    Console.WriteLine("Batch Number: " + drug.BatchNo);
                                                    Console.WriteLine("Drug Dosage Id: " + drug.DrugDosageInvolvedId);
                                                    Console.WriteLine("Drug Dose: " + drug.DrugDose);
                                                    Console.WriteLine();
                                                }
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid Choice");
                                            }

                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Choice");
                                    }

                                }
                                break;
                                
                            }

                            if (choice1 == "5")
                            {
                                while (true)
                                {
                                    Console.Clear(); Console.WriteLine("CONSULTATION MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                    Console.WriteLine("1-New Consultation\n2-Previous Consultation");
                                    string choice2 = Console.ReadLine();
                                    if (choice2 == "1")
                                    {
                                        Console.Clear(); Console.WriteLine("CONSULTATION MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                        Console.WriteLine("New Consultation");
                                        Consultation objConsultation1 = new Consultation();
                                        objConsultation1.PrescriptionId = Hospital.SetPrescriptionId();
                                        Console.WriteLine("Enter the Appointment Booking Id");
                                        objConsultation1.AppointmentDetails = Console.ReadLine();
                                        objConsultation1.CPhysician = Hospital.FetchAppointmentDetails(objConsultation1.AppointmentDetails).PreferredDoctor;
                                        objConsultation1.PrescriptionDate = DateTime.Now;
                                        Console.WriteLine("Enter the Diagnosis");
                                        objConsultation1.Diagnosis = Console.ReadLine();
                                        objConsultation1.Dosage = Hospital.SetDrugDosageId();
                                        DrugDosage objDrugDosage = new DrugDosage();
                                        objDrugDosage.DrugDosageId = objConsultation1.Dosage;

                                        Console.WriteLine("Enter the number of drugs to be given");
                                        int noOfDrugs = Convert.ToInt32(Console.ReadLine());
                                        for(int i =1;i<=noOfDrugs;i++)
                                        {
                                            Console.WriteLine("Enter the Drug " + i + " Id:");
                                            string drugId= Console.ReadLine();
                                            Hospital.UpdateDrugDosageInvolved(drugId, objConsultation1.Dosage);
                                            Console.WriteLine("Enter the dose for this drug:");
                                            string dose = Console.ReadLine();
                                            Hospital.UpdateDrugDose(drugId, dose);
                                        }
                                        Console.WriteLine("Enter the DrugDosage Duration");
                                        objDrugDosage.DosageDuration = Console.ReadLine();
                                        Hospital.AssignDosage(objDrugDosage);
                                        Console.WriteLine(Hospital.Consult(objConsultation1));
                                        Console.Clear();
                                        Console.WriteLine("CONSULTATION MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                        Console.WriteLine("Consultation Slip"); Console.WriteLine(); Console.WriteLine();
                                        Consultation objConsultation = Hospital.FetchConsultationSlip(objConsultation1.PrescriptionId);
                                        Console.WriteLine("PrescriptionId: " + objConsultation.PrescriptionId);
                                        Console.WriteLine("PrescriptionDate: "+objConsultation.PrescriptionDate);
                                        Console.WriteLine("Physician Id: "+objConsultation.CPhysician);
                                        Console.WriteLine("AppointmentDetails: "+objConsultation.AppointmentDetails);
                                        Console.WriteLine("Diagnosis: "+objConsultation.Diagnosis);
                                        Console.WriteLine("DrugDosageId: " + objConsultation.Dosage);
                                        Console.WriteLine("DrugDosage Duration: " + objDrugDosage.DosageDuration);
                                        List<Drug> listDrugs = Hospital.FetchAllDrugsInDosage(Hospital.FetchDosageById(objDrugDosage.DrugDosageId).DrugDosageId);
                                        foreach (Drug drug in listDrugs)
                                        {
                                            Console.WriteLine("Drug Id: " + drug.DrugId);
                                            Console.WriteLine("Drug Name: " + drug.DrugName);
                                            Console.WriteLine("Brand Name: " + drug.BrandName);
                                            Console.WriteLine("Batch Number: " + drug.BatchNo);
                                            Console.WriteLine("Drug Dose: " + drug.DrugDose);
                                            Console.WriteLine();
                                        }


                                        break;
                                    }
                                    else if (choice2 == "2")
                                    {
                                        while (true)
                                        {
                                            Console.Clear(); Console.WriteLine("CONSULTATION MAINTAINANCE"); Console.WriteLine(); Console.WriteLine();
                                            Console.WriteLine("Previous Consultation");
                                            Console.WriteLine("How may we help you: "); Console.WriteLine(); Console.WriteLine();
                                            Console.WriteLine("1: Fetch Consultation Details by PrescriptionId");

                                                Console.WriteLine("Enter the Prescription Id");
                                                string pcnId = Console.ReadLine();
                                                Consultation objConsultation2=Hospital.FetchConsultationSlip(pcnId);
                                                Console.WriteLine("PrescriptionId: " + objConsultation2.PrescriptionId);
                                                Console.WriteLine("PrescriptionDate: " + objConsultation2.PrescriptionDate);
                                                Console.WriteLine("Physician Id: " + objConsultation2.CPhysician);
                                                Console.WriteLine("AppointmentDetails: " + objConsultation2.AppointmentDetails);
                                                Console.WriteLine("Diagnosis: " + objConsultation2.Diagnosis);
                                                Console.WriteLine("DrugDosageId: " + objConsultation2.Dosage);
                                                Console.WriteLine("DrugDosage Duration: " + Hospital.FetchDosageById(objConsultation2.Dosage).DosageDuration);
                                                break;
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Choice");
                                    }

                                }
                                break;
                            }

                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid Choice! Please enter again");
                                Console.WriteLine();
                            }
                        }



                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.InnerException);

                    }

                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid username or password! Please try again.\nRemaining number of attemtps "+ (_numberOfAttempts-1));
                    _numberOfAttempts--;
                    if(_numberOfAttempts==0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Too Many Failed Attmepts\nPlease try again after 10 minutes");
                        break;
                    }
                }

            }


            Console.ReadKey();
        }
    }
}