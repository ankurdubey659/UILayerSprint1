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
                string password = Console.ReadLine();//have to make it invisible and replace it by stars
                if (5>4/*Admin.isValidAdmin(username, password)*/)
                {
                    Console.Clear();
                    try
                    {


                        while (true)
                        {
                            Console.WriteLine("1-Physician Maintenance\n2-Patient maintenance\n3-Appointment maintenance\n4-Drug maintenance\n5-Consultation maintenance");
                            string choice1 = Console.ReadLine();
                            if (choice1 == "1")
                            {Console.Clear(); Console.WriteLine("PYSICIAN MAINTAINANCE\r\r");Console.WriteLine();Console.WriteLine();

                                Console.WriteLine("1-New Physician\n2-Existing Physician");
                                string choice2= Console.ReadLine();
                                switch (choice2)
                                {
                                    case "1":
                                        Console.Clear(); Console.WriteLine("PYSICIAN MAINTAINANCE\r\r"); Console.WriteLine(); Console.WriteLine();
                                        Console.WriteLine("New Physician");
                                        Physician objPhysician1 = new Physician();
                                        objPhysician1.PhysicianId = Hospital.SetPhysicianId();
                                        Console.WriteLine("Enter your First Name");
                                        objPhysician1.PhysicianFirstName= Console.ReadLine();
                                        Console.WriteLine("Enter your Middle Name");
                                        objPhysician1.PhysicianMiddleName = Console.ReadLine();
                                        Console.WriteLine("Enter your Last Name");
                                        objPhysician1.PhysicianLastName = Console.ReadLine();
                                        Console.WriteLine("Enter your Specialities");
                                        objPhysician1.PhysicianSpeciality = Console.ReadLine();
                                        Console.WriteLine("Enter your Highest Qualification");
                                        objPhysician1.PhysicianQualification = Console.ReadLine();
                                        Console.WriteLine("Enter your Phone Number");
                                        objPhysician1.PhysicianPhoneNumber = Convert.ToInt64(Console.ReadLine());
                                        Console.WriteLine("Enter your Email-Id");
                                        objPhysician1.PhysicianEmail= Console.ReadLine();
                                        Console.WriteLine(Hospital.NewPhysician(objPhysician1));
                                        Console.Clear();
                                        Console.WriteLine("PYSICIAN MAINTAINANCE");Console.WriteLine();Console.WriteLine();
                                        Console.WriteLine("New Physician");Console.WriteLine();Console.WriteLine();
                                        Physician objPhysician = Hospital.FetchPhysicianById(objPhysician1.PhysicianId);
                                        Console.WriteLine("Name: " + objPhysician.PhysicianFirstName + " " + objPhysician.PhysicianMiddleName + " " + objPhysician.PhysicianLastName);
                                        Console.WriteLine("Specialities: " + objPhysician.PhysicianSpeciality);
                                        Console.WriteLine("Highest Qualification: " + objPhysician.PhysicianQualification);
                                        Console.WriteLine("Phone Number: " + objPhysician.PhysicianPhoneNumber);
                                        Console.WriteLine("Email-Id: " + objPhysician.PhysicianEmail);

                                        break;
                                    case "2":
                                        Console.Clear(); Console.WriteLine("PYSICIAN MAINTAINANCE\r\r"); Console.WriteLine(); Console.WriteLine();
                                        Console.WriteLine("Existing Physician");
                                        Console.WriteLine("How may we help you: ");Console.WriteLine();Console.WriteLine();
                                        Console.WriteLine("1: Fetch Physician's Details by Id");
                                        Console.WriteLine("2: Fetch all the Physician's Details");
                                        Console.WriteLine("3: Delete a Physician's Record");
                                        Console.WriteLine("4: Update a Physician's Details");

                                        string choice3 = Console.ReadLine();
                                        switch(choice3)
                                        {
                                            case "1":
                                                Console.Clear(); Console.WriteLine("PYSICIAN MAINTAINANCE\r\r"); Console.WriteLine(); Console.WriteLine();
                                                Console.WriteLine("Fetching Physician's Details by Id");
                                                Console.WriteLine("Enter the Physician's Id");
                                                    string phyId1 = Console.ReadLine();
                                                    Physician objPhysician2 = Hospital.FetchPhysicianById(phyId1);
                                                    Console.WriteLine("Name: " + objPhysician2.PhysicianFirstName + " " + objPhysician2.PhysicianMiddleName + " " + objPhysician2.PhysicianLastName);
                                                    Console.WriteLine("Specialities: " + objPhysician2.PhysicianSpeciality);
                                                    Console.WriteLine("Highest Qualification: " + objPhysician2.PhysicianQualification);
                                                    Console.WriteLine("Phone Number: " + objPhysician2.PhysicianPhoneNumber);
                                                    Console.WriteLine("Email-Id: " + objPhysician2.PhysicianEmail);
                                                 break;
                                                
                                            case "2":
                                                Console.Clear(); Console.WriteLine("PYSICIAN MAINTAINANCE\r\r"); Console.WriteLine(); Console.WriteLine();
                                                Console.WriteLine("Fetching all the Physician's Details");
                                                List<Physician> physiciansList = Hospital.FetchAllPhysicians();
                                                    foreach (Physician physician in physiciansList)
                                                    {
                                                        Console.WriteLine("Name: " + physician.PhysicianFirstName + " " + physician.PhysicianMiddleName + " " + physician.PhysicianLastName);
                                                        Console.WriteLine("Specialities: " + physician.PhysicianSpeciality);
                                                        Console.WriteLine("Highest Qualification: " + physician.PhysicianQualification);
                                                        Console.WriteLine("Phone Number: " + physician.PhysicianPhoneNumber);
                                                        Console.WriteLine("Email-Id: " + physician.PhysicianEmail);
                                                        Console.WriteLine();
                                                    }
                                                break;
                                            case "3":
                                                Console.Clear(); Console.WriteLine("PYSICIAN MAINTAINANCE\r\r"); Console.WriteLine(); Console.WriteLine();
                                                Console.WriteLine("Deleting Physician's record");
                                                Console.WriteLine("Enter the Physician's Id to be deleted");
                                                string phyId2 = Console.ReadLine();
                                                Hospital.DeletePhysician(phyId2);
                                                break;
                                            case "4":
                                                Console.Clear(); Console.WriteLine("PYSICIAN MAINTAINANCE\r\r"); Console.WriteLine(); Console.WriteLine();
                                                Console.WriteLine("Updating Physician's Details");
                                                Console.WriteLine("Enter the Physician's Id");
                                                string phyId3 = Console.ReadLine();
                                                Console.Clear();
                                                Console.WriteLine("1:Update Physician's Name");
                                                Console.WriteLine("2:Update Physician's Phone Number");
                                                Console.WriteLine("3:Update Physician's Specialities");
                                                Console.WriteLine("4:Update Physician's Highest Qualification");
                                                Console.WriteLine("5:Update Physician's Email-Id");

                                                string choice4 = Console.ReadLine();
                                                switch (choice4)
                                                {
                                                    case "1":
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
                                                    case "2":
                                                        Console.WriteLine("Enter the new Phone Number");
                                                        string phyPN = Console.ReadLine();
                                                        long newPN = Convert.ToInt64(phyPN);
                                                        Hospital.ModifyPhysicianPhoneNumber(phyId3, newPN);
                                                        break;
                                                    case "3":
                                                        Console.WriteLine("Enter the Specialities to be Updated");
                                                        string phySpeciality= Console.ReadLine();
                                                        Hospital.ModifyPhysicianSpeciality(phyId3, phySpeciality);
                                                        break;
                                                    case "4":
                                                        Console.WriteLine("Enter the New Highest Qualification");
                                                        string phyQualification = Console.ReadLine();
                                                        Hospital.ModifyPhysicianQualification(phyId3, phyQualification);
                                                        break;
                                                    case "5":
                                                        Console.WriteLine("Enter your new Email");
                                                        string phyEmail = Console.ReadLine();
                                                        Hospital.ModifyPhysicianEmail(phyId3, phyEmail);
                                                        break;
                                                    default:
                                                        Console.WriteLine("Invalid Choice");
                                                        break;                                                     
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("Invalid Choice");
                                                break;
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Invalid Choice");
                                        break;
                                }
                                 


                                break;
                            }
                            else if (choice1 == "2")
                            {
                                Console.Clear();
                                Console.WriteLine("PATIENT MAINTAINANCE");
                                Console.WriteLine();
                                Console.WriteLine();
                                break;
                            }
                            else if (choice1 == "3")
                            {
                                Console.Clear();
                                Console.WriteLine("APPOINTMENT MAINTAINANCE");
                                Console.WriteLine();
                                Console.WriteLine();
                            }
                            else if (choice1 == "4")
                            {
                                Console.Clear();
                                Console.WriteLine("DRUG MAINTAINANCE");
                                Console.WriteLine();
                                Console.WriteLine();
                                break;
                            }
                            if (choice1 == "5")
                            {
                                Console.Clear();
                                Console.WriteLine("CONSULTATION MAINTAINANCE");
                                Console.WriteLine();
                                Console.WriteLine();
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

                    catch(NullReferenceException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.InnerException);

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