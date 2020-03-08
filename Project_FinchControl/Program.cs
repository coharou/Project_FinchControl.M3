using System;
using static System.Console;
using static System.ConsoleColor;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    //-----------------------------------------------------------------------------------------------------------
    //      Application:    Finch Control (Mission 3 Sprint 3)
    //      App. Type:      Console
    //      Author:         Haroutunian, Colin B
    //
    //      Description:    An application for the Finch Control. 
    //                      It is based on the starter solution.
    //                      
    //      Date Created:   February 23rd, 2020
    //      Date Revised:   March 8th, 2020
    //-----------------------------------------------------------------------------------------------------------


    class Program
    {
        #region APPLICATION START
        /// <summary>
        /// *****************************************************************
        /// *                    Application start                          *
        /// *****************************************************************
        /// </summary>
        /// 
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            CursorVisible = false;
            Clear();
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            ForegroundColor = Black;
            BackgroundColor = White;
        }
        #endregion

        #region MAIN MENU
        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            CursorVisible = false;
            Clear();

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                WriteLine("\t1) Connect Finch Robot");
                WriteLine("\t2) Talent Show");
                WriteLine("\t3) Data Recorder");
                WriteLine("\t4) Alarm System");
                WriteLine("\t5) User Programming");
                WriteLine("\t6) Disconnect Finch Robot");
                WriteLine("\t7) Quit");
                Write("\t\tEnter Choice: ");
                CursorVisible = true;
                menuChoice = ReadLine();
                

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "1":
                        DisplayConnectScreen();
                        DisplayConnectPrompt(finchRobot);
                        DisplayMenuPrompt("Main Menu");
                        break;

                    case "2":
                        DisplayTalentShowMenuScreen(finchRobot);
                        break;

                    case "3":
                        DisplayDataRecorderMenuScreen(finchRobot);
                        break;

                    case "4":
                        DisplayAlarmMenuScreen(finchRobot);
                        break;

                    case "5":

                        break;

                    case "6":
                        DisplayDisconnectScreen();
                        DisplayDisconnectPrompt(finchRobot);
                        DisplayMenuPrompt("Main Menu");
                        break;

                    case "7":
                        quitApplication = DisplayQuitInformation();
                        break;

                    default:
                        WriteLine();
                        WriteLine("\tPlease enter a number, 1 through 7, for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }
        #endregion

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                    Talent Show Menus                          *
        /// *****************************************************************
        /// </summary>
        static void DisplayTalentShowMenuScreen(Finch myFinch)
        {
            CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                WriteLine("\t1) Two Octaves (in C)");
                WriteLine("\t2) Figure Eight Display");
                WriteLine("\t3) Everything at Once");
                WriteLine("\t4) Main Menu");
                Write("\t\tEnter Choice: ");
                menuChoice = ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "1":
                        EnterTwoOctaves(myFinch);
                        break;

                    case "2":
                        EnterFigureEight(myFinch);
                        break;

                    case "3":
                        EnterEverything(myFinch);
                        break;

                    case "4":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        WriteLine();
                        WriteLine("\tPlease enter a number, 1 through 5, for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *                    Talent Show Options                        *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        static void EnterTwoOctaves(Finch finchRobot)
        {
            int[] octaveArray;
            octaveArray = new int[14] {262, 294, 330, 349, 392, 440, 494, 523, 587, 659, 698, 784, 880, 988};
            foreach (int octaveNote in octaveArray)
            {
                if (octaveNote >= 587)
                {
                    finchRobot.setLED(255, 94, 92);
                }
                else
                {
                    finchRobot.setLED(255, 232, 132);
                }
                finchRobot.noteOn(octaveNote);
                finchRobot.wait(150);
            }
            finchRobot.noteOn(1047);
            finchRobot.wait(450);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);
        }

        static void EnterFigureEight(Finch finchRobot)
        {
            finchRobot.setMotors(255, 255);
            finchRobot.wait(100);
            for (int motorCycle = 0; motorCycle < 2; motorCycle++)
            {
                finchRobot.setMotors(147, 255);
                finchRobot.wait(400);
                finchRobot.setMotors(0, 147);
                finchRobot.wait(400);
            }
            finchRobot.setMotors(147, 255);
            finchRobot.wait(400);
            finchRobot.setMotors(255, 255);
            finchRobot.wait(280);
            for (int motorCycle2 = 0; motorCycle2 < 2; motorCycle2++)
            {
                finchRobot.setMotors(255, 147);
                finchRobot.wait(400);
                finchRobot.setMotors(147, 0);
                finchRobot.wait(400);
            }
            finchRobot.setMotors(255, 147);
            finchRobot.wait(400);
            finchRobot.setMotors(255, 255);
            finchRobot.wait(280);
            for (int motorCycle2 = 0; motorCycle2 < 2; motorCycle2++)
            {
                finchRobot.setMotors(255, 147);
                finchRobot.wait(400);
                finchRobot.setMotors(147, 0);
                finchRobot.wait(400);
            }
            finchRobot.setMotors(255, 147);
            finchRobot.wait(400);
            finchRobot.setMotors(255, 255);
            finchRobot.wait(280);
            for (int motorCycle = 0; motorCycle < 2; motorCycle++)
            {
                finchRobot.setMotors(147, 255);
                finchRobot.wait(400);
                finchRobot.setMotors(0, 147);
                finchRobot.wait(400);
            }
            finchRobot.setMotors(147, 255);
            finchRobot.wait(400);
            finchRobot.setMotors(255, 255);
            finchRobot.wait(280);
            finchRobot.setMotors(0, 0);
        }

        static void EnterEverything(Finch finchRobot)
        {
            int soundVal;
            soundVal = EnterEverythingSound();
            int motorLVal;
            motorLVal = EnterEverythingMotorLeft();
            int motorRVal;
            motorRVal = EnterEverythingMotorRight();

            WriteLine("\tWhen you are ready to see the robot perform, press any button.");
            ReadKey(intercept: true);

            finchRobot.setMotors(motorLVal, motorRVal);
            finchRobot.setLED(255, motorLVal, motorRVal);
            finchRobot.noteOn(soundVal);
            finchRobot.wait(3000);
            finchRobot.setMotors(0, 0);
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

        }

        static int EnterEverythingSound()
        {
            Clear();
            DisplayEnterEverythingSoundPrompt();
            DisplayContinuePrompt();
            int soundValue;
            soundValue = 0;
            Write("\tEnter a value for sound: ");
            do
            {
                soundValue = Convert.ToInt32(ReadLine());
                if (soundValue < 250 || soundValue > 1000)
                {
                    WriteLine("\tPlease only enter values between 250 and 1000.");
                    WriteLine();
                    Write("\tEnter a value for the sound: ");
                }
            } while (soundValue < 250 || soundValue > 1000);

            return soundValue;
        }

        static int EnterEverythingMotorLeft()
        {
            Clear();
            DisplayEnterEverythingMotor("left");
            DisplayContinuePrompt();
            int motorLeft;
            motorLeft = 256;
            Write("\tEnter a value for the left motor: ");
            do
            {
                motorLeft = Convert.ToInt32(ReadLine());
                if (motorLeft < 0 || motorLeft > 255)
                {
                    WriteLine("\tPlease only enter values between 250 and 1000");
                    WriteLine();
                    Write("\tEnter a value for the left motor: ");
                }
            } while (motorLeft < 0 || motorLeft > 255);

            return motorLeft;
        }

        static int EnterEverythingMotorRight()
        {
            Clear();
            DisplayEnterEverythingMotor("right");
            DisplayContinuePrompt();
            int motorRight;
            motorRight = 256;
            Write("\tEnter a value for the right motor: ");
            do
            {
                motorRight = Convert.ToInt32(ReadLine());
                if (motorRight < 0 || motorRight > 255)
                {
                    WriteLine("\tPlease only enter values between 250 and 1000");
                    WriteLine();
                    Write("\tEnter a value for the right motor: ");
                }
            } while (motorRight < 0 || motorRight > 255);

            return motorRight;
        }

        #endregion

        #region DATA RECORDER
        static void DisplayDataRecorderMenuScreen(Finch myFinch)
        {
            CursorVisible = true;
            string goToCase;
            bool backToMain;
            backToMain = false;
            do
            {
                DisplayDataRecorderMenuPrompt();
                WriteLine("\t1) Temperature recording");
                WriteLine("\t2) Light value recording");
                WriteLine("\t3) Return to Main Menu");
                WriteLine();
                Write("\tEnter your choice here: ");
                CursorVisible = true;
                goToCase = ReadLine();
                switch (goToCase)
                {
                    case "1":
                        EnterRecording(myFinch, "Temperature");
                        break;
                    case "2":
                        EnterRecording(myFinch, "Light");
                        break;
                    case "3":
                        backToMain = true;
                        break;
                    default:
                        WriteLine("\tPlease only enter:");
                        WriteLine("\t1 for temperature recording,");
                        WriteLine("\t2 for light value recording,");
                        WriteLine("\t3 to return to the main menu.");
                        DisplayContinuePrompt();
                        break;
                }
            } while (backToMain == false);
        }

        static void EnterRecording(Finch finchRobot, string typeRecorded)
        {
            DisplayDataTypeSelectionPrompt(typeRecorded);
            WriteLine();
            WriteLine("\tAre you sure you want to do this?");

            bool confirmationResponse = GeneralConfirmation();
            if (confirmationResponse == true)
            {
                Clear();
                int theirSampleSize;
                theirSampleSize = DataTypeSampleSize(typeRecorded);
                BuildTheArrays(finchRobot, theirSampleSize, typeRecorded);
                DisplayContinuePrompt();
            }
            else
            {
            }
        }

        static int DataTypeSampleSize(string dataDecision)
        {
            bool newConfirmation;
            int desiredSample;

            do
            {
                WriteLine();
                WriteLine("\tYou will now be entering a sample size for the " + dataDecision + " recording.");
                WriteLine("\tA sample will be taken every 2 seconds, so please keep that in mind when making your choice.");
                WriteLine();
                Write("\tEnter the desired sample size: ");

                desiredSample = DataTypeSampleSizeDesired();

                Clear();
                WriteLine();
                WriteLine("\tYour chosen sample is " + desiredSample + ".");
                WriteLine("\tThis will take approximately " + desiredSample * 2 + " seconds.");
                WriteLine();
                WriteLine("\tAre you sure you want to do this?");

                newConfirmation = GeneralConfirmation();
                if (newConfirmation == false)
                {
                    WriteLine();
                    WriteLine("\tPlease re-enter your desired values, then.");
                    DisplayContinuePrompt();
                    Clear();
                }
                else
                {

                }
            } while (newConfirmation == false);

            return desiredSample;
        }

        static int DataTypeSampleSizeDesired()
        {
            int desiredSample;
            bool sampleQuality;
            do
            {
                sampleQuality = int.TryParse(ReadLine(), out desiredSample);
                if (sampleQuality == false)
                {
                    WriteLine();
                    WriteLine("\tPlease only respond with number values, like '10' '25' or '50'.");
                    desiredSample = 0;
                    Write("\tEnter the desired sample size: ");
                    sampleQuality = int.TryParse(ReadLine(), out desiredSample);
                }
                else
                {
                }
            } while (sampleQuality == false);
            return desiredSample;
        }

        static void BuildTheArrays(Finch finchRobot, int theirSampleSize, string typeRecorded)
        {
            int[] firstArray;
            firstArray = new int[theirSampleSize];
            int[] secondArray;
            secondArray = new int[theirSampleSize];
            int[] numberingArray;
            numberingArray = new int[theirSampleSize];

            string typeOne;
            typeOne = "";
            string typeTwo;
            typeTwo = "";

            int firstTotal;
            firstTotal = 0;
            int secondTotal;
            secondTotal = 0;

            if (typeRecorded == "Temperature")
            {
                finchRobot.setLED(255, 0, 0);
                finchRobot.noteOn(500);
                typeOne = "CELCIUS";
                typeTwo = "FAHRENHEIT";

                WriteLine("\tHere are your values for the " + typeRecorded + ".");
                WriteLine();
                WriteLine("\t" + "ORDER" + "          " + typeOne + "            " + typeTwo);

                //INDIVIDUAL DATA
                for (int sample = 0; sample < theirSampleSize; sample++)
                {
                    firstArray[sample] += Convert.ToInt32(finchRobot.getTemperature());
                    secondArray[sample] += CelciusToFahrenheit(finchRobot);
                    numberingArray[sample] += sample;
                    WriteLine("\t" + numberingArray[sample] + "               " + firstArray[sample] + "               " + secondArray[sample]);
                    finchRobot.wait(2000);
                }
                
                //AVERAGED DATA
                for (int sample = 0; sample < theirSampleSize; sample ++)
                {
                    firstTotal = firstTotal + firstArray[sample];
                    secondTotal = secondTotal + secondArray[sample];
                }

                int firstAverage = firstTotal / theirSampleSize;
                int secondAverage = secondTotal / theirSampleSize;
                WriteLine("\t" + " " + "               " + firstAverage + "               " + secondAverage);
            }

            if (typeRecorded == "Light")
            {
                finchRobot.setLED(0, 125, 125);
                finchRobot.noteOn(500);
                typeOne = "LEFT";
                typeTwo = "RIGHT";

                WriteLine("\tHere are your values for the " + typeRecorded + ".");
                WriteLine();
                WriteLine("\t" + "ORDER" + "          " + typeOne + "            " + typeTwo);

                //INDIVIDUAL DATA
                for (int sample = 0; sample < theirSampleSize; sample++)
                {
                    firstArray[sample] += finchRobot.getLeftLightSensor();
                    secondArray[sample] += finchRobot.getRightLightSensor();
                    numberingArray[sample] += sample;
                    WriteLine("\t"+ numberingArray[sample] + "               " + firstArray[sample] + "               " + secondArray[sample]);
                    finchRobot.wait(2000);
                }

                //AVERAGED DATA
                for (int sample = 0; sample < theirSampleSize; sample++)
                {
                    firstTotal = firstTotal + firstArray[sample];
                    secondTotal = secondTotal + secondArray[sample];
                }

                int firstAverage = firstTotal / theirSampleSize;
                int secondAverage = secondTotal / theirSampleSize;
                WriteLine("\t" + " " + "               " + firstAverage + "               " + secondAverage);
            }

            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();
        }

        static int CelciusToFahrenheit(Finch finchRobot)
        {
            int fahrenheitVal;
            fahrenheitVal = (Convert.ToInt32(finchRobot.getTemperature()) * 9) / 5 + 32;
            return fahrenheitVal;
        }

        #endregion

        #region ALARM SYSTEM
        static void DisplayAlarmMenuScreen(Finch myFinch)
        {
            bool keepMenu;
            keepMenu = true;
            bool userContinue;
            userContinue = true;
            do
            {
                DisplayAlarmMenuPrompt();
                WriteLine("\tAre you sure you want to do this?");
                userContinue = GeneralConfirmation();
                if (userContinue == true)
                {
                    int[] tempRange = BuildValueThreshold("temperature");
                    int[] lightRange = BuildValueThreshold("light");
                    int monitorTime = ObtainTime();
                    DisplayMonitorPrompt();
                    StartMonitor(myFinch, tempRange, lightRange, monitorTime);
                    DisplayContinuePrompt();
                }
                else
                    keepMenu = false;
            } while (keepMenu == true);
        }

        static int[] BuildValueThreshold(string valueString)
        {
            bool userRes;
            userRes = AskAboutValue(valueString);

            if (userRes == true)
            {
                int minThres;
                minThres = SetUpValue(valueString, "minimum");

                int maxThres;
                maxThres = SetUpValue(valueString, "maximum");

                int[] valueArray = new int[] {1, minThres, maxThres};
                return valueArray;
            }
            else
            {
                int[] valueArray = new int[] {0};
                return valueArray;
            }
        }

        static bool AskAboutValue(string valueString)
        {
            Clear();
            WriteLine();
            WriteLine("\t" + valueString.ToUpper());
            WriteLine();
            WriteLine("\tFor the alarm, would you like to test the " + valueString + "?");

            bool userConfirmation;
            userConfirmation = GeneralConfirmation();
            return userConfirmation;
        }

        static int SetUpValue(string valueString, string thresType)
        {
            DisplayScreenHeader(valueString.ToUpper());
            WriteLine("\tHere, you will enter in the values for the {0} of the {1} test.", thresType, valueString);
            WriteLine("\tPlease do so with whole number values, like '0', '32', or '212'.");
            if (valueString == "temperature")
            {
                WriteLine("\tWith " + valueString + ", the values will be in Celcius.");
            }
            WriteLine();
            int newValue;
            newValue = NumberResponse();
            DisplayContinuePrompt();
            return newValue;
        }

        static int ObtainTime()
        {
            DisplayScreenHeader("Alarm System");
            WriteLine("\tHere, you will be entering in how long the temperature and light will be monitored for.");
            WriteLine("\tThe units are in seconds, but will be converted to milliseconds for the monitors.");
            WriteLine();

            bool userConfirmation;
            userConfirmation = false;

            int timeToMonitor;

            do
            {
                timeToMonitor = NumberResponse();
                WriteLine("\tYou entered " + timeToMonitor + " seconds.");
                WriteLine();
                WriteLine("\tAre you fine with this value?");
                userConfirmation = GeneralConfirmation();
                if (userConfirmation == false)
                    WriteLine("\tPlease resubmit your values, then.");
            } while (userConfirmation == false);

            return timeToMonitor;
        }

        static int NumberResponse()
        {
            int newValue;

            bool userResponse;
            userResponse = false;

            do
            {
                Write("\tEnter your desired value here: ");
                userResponse = int.TryParse(ReadLine(), out newValue);
                if (userResponse == false)
                {
                    WriteLine("\tPlease only type in whole number values for the range.");
                    WriteLine();
                }
            } while (userResponse == false);

            return newValue;
        }

        static void StartMonitor(Finch finchRobot, int[] tempRange, int[] lightRange, int monitorTime)
        {
            bool startAlarm;
            startAlarm = false;
            int cycleTime;
            cycleTime = 0;
            string alarmType;
            alarmType = "";

            WriteLine();
            Write("\t");
            do
            {
                Write(".");
                finchRobot.wait(1000);
                if (tempRange[0] != 0)
                {
                    int[] tempMonitor = MonitorSpecific(finchRobot, "temperature", tempRange);
                    if (tempMonitor[0] <= tempRange[1] || tempMonitor[0] >= tempRange[2])
                    {
                        startAlarm = true;
                        alarmType = "temperature";
                        WriteLine();
                        WriteLine();
                        WriteLine("\tTemperature monitor 1: {0}.", tempMonitor[0]);
                    }
                }
                if (lightRange[0] != 0)
                {
                    int[] lightMonitor = MonitorSpecific(finchRobot, "light", lightRange);
                    if (lightMonitor[0] <= lightRange[1] || lightMonitor[0] >= lightRange[2] || lightMonitor[1] <= lightRange[1] || lightMonitor[1] >= lightRange[2])
                    {
                        startAlarm = true;
                        alarmType = "light";
                        WriteLine();
                        WriteLine();
                        WriteLine("\tLight monitor 1: {0}. Light monitor 2: {1}.", lightMonitor[0], lightMonitor[1]);
                    }
                }
                cycleTime = cycleTime + 1;
            } while (startAlarm == false && cycleTime <= monitorTime);

            if (startAlarm == true)
            {
                WriteLine("\tThe alarm has been activated! One of the values passed the range you set.");
                MonitorAlarm(finchRobot, alarmType);
            }
            else
            {
                WriteLine("\tThe threshold was not passed for the duration of time specified.");
            }
        }

        static void MonitorAlarm(Finch finchRobot, string alarmType)
        {
            if (alarmType == "temperature")
            {
                finchRobot.noteOn(1150);
                finchRobot.setLED(255, 0, 0);
            }
            else
            {
                finchRobot.noteOn(850);
                finchRobot.setLED(255, 255, 0);
            }
            finchRobot.wait(5000);
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();
        }

        static int[] MonitorSpecific (Finch finchRobot, string valueString, int[] valueRange)
        {
            int typeMonitored;
            int typeMonitoredAlt;
            if (valueString == "temperature")
            {
                typeMonitored = Convert.ToInt32(finchRobot.getTemperature());
                int[] monitorArray = new int[] {typeMonitored};
                return monitorArray;
            }
            else
            {
                typeMonitored = Convert.ToInt32(finchRobot.getLeftLightSensor());
                typeMonitoredAlt = Convert.ToInt32(finchRobot.getRightLightSensor());
                int[] monitorArray = new int[] { typeMonitored, typeMonitoredAlt };
                return monitorArray;
            }
        }

        #endregion

        #region FINCH ROBOT MANAGEMENT
        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectPrompt(Finch finchRobot)
        {
            ConsoleKeyInfo keyCode;
            WriteLine();
            WriteLine("\tAre you sure that you want to disconnect?");
            WriteLine("\tPress ENTER to continue. Press ESC to go back to the main menu.");
            keyCode = ReadKey(intercept: true);
            if (keyCode.Key == ConsoleKey.Enter)
            {
                DisconnectionDoneSound(finchRobot);
                finchRobot.disConnect();
            }
            if(keyCode.Key == ConsoleKey.Escape)
            {
            }
            if(keyCode.Key != ConsoleKey.Escape && keyCode.Key != ConsoleKey.Enter)
            {
                string keyCodeString;
                keyCodeString = Convert.ToString(keyCode.Key);
                WriteLine();
                WriteLine("\tYou entered " + keyCodeString + ".");
                DisplayTryAgainPrompt();
            }
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectPrompt(Finch finchRobot)
        {
            ConsoleKeyInfo keyCode;
            WriteLine();
            WriteLine("\tAre you sure that you want to connect?");
            WriteLine("\tPress ENTER to continue. Press ESC to go back to the main menu.");
            keyCode = ReadKey(intercept:true);
            if (keyCode.Key == ConsoleKey.Enter)
            {
                ConnectFinchRobot(finchRobot);
                ConnectionDoneSound(finchRobot);
            }
            if (keyCode.Key != ConsoleKey.Escape && keyCode.Key != ConsoleKey.Enter)
            {
                string keyCodeString;
                keyCodeString = Convert.ToString(keyCode.Key);
                WriteLine();
                WriteLine("\tYou entered " + keyCodeString + ".");
                DisplayTryAgainPrompt();
                return false;
            }
            else
            {
                return false;
            }
        }
        static bool ConnectFinchRobot(Finch finchRobot)
        {
            CursorVisible = false;
            bool robotConnected;
            robotConnected = finchRobot.connect();
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();
            return robotConnected;
        }

        /// <summary>
        /// *****************************************************************
        /// *               Quit Using the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        static bool DisplayQuitInformation()
        {
            CursorVisible = false;
            Clear();
            WriteLine("\tBefore you go, have you disconnected the Finch Robot?");
            WriteLine("\tPress ENTER if so. If not, press ESC.");
            ConsoleKeyInfo keyInfo;
            string keyPressed;
            do
            {
                keyInfo = ReadKey(intercept: true);
                keyPressed = Convert.ToString(keyInfo.Key);
                if (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Escape)
                {
                    WriteLine();
                    WriteLine("\tYou pressed the key " + keyPressed + ".");
                    WriteLine("\tPlease only press ENTER if you disconnected, or ESC if you haven't.");
                }
            } while (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Escape);
            if (keyPressed == "Enter")
            {
                    return true;
            }
            else
            {
                    WriteLine();
                    WriteLine("\tYou need to disconnect the Finch Robot, then.");
                    WriteLine("\tGo to the main menu and press '6' to go to the disconnect screen.");
                    DisplayMenuPrompt("Main Menu");
                    return false;
            }
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            CursorVisible = false;

            Clear();
            WriteLine();
            WriteLine("\tFinch Control");
            WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            CursorVisible = false;

            Clear();
            WriteLine();
            WriteLine("\tThank you for using Finch Control!");
            WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                   Connection Screens                          *
        /// *****************************************************************
        /// </summary>
        static void DisplayDisconnectScreen()
        {
            CursorVisible = false;
            DisplayScreenHeader("Disconnect Finch Robot");
            WriteLine("\tAbout to disconnect from the Finch robot.");
        }

        static void DisplayConnectScreen()
        {
            CursorVisible = false;
            DisplayScreenHeader("Connect Finch Robot");
            WriteLine("\tAbout to connect to the Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Screens                       *
        /// *****************************************************************
        /// </summary>
        static void DisplayEnterEverythingSoundPrompt()
        {
            WriteLine();
            WriteLine("\tIn a moment, you will be entering a whole number between 250 and 1000.");
            WriteLine("\tThis will be the note frequency played when the talent show begins.");
            WriteLine("\tPlease think of the value now, before heading forward.");
        }

        static void DisplayEnterEverythingMotor(string motorType)
        {
            WriteLine();
            WriteLine("\tIn a moment, you will be entering a whole number between 0 and 255.");
            WriteLine("\tThis will be the speed of the " + motorType + " motor when the talent show begins.");
            WriteLine("\tPlease think of the value now, before heading forward.");
        }

        /// <summary>
        /// *****************************************************************
        /// *                   Data Recorder Screens                       *
        /// *****************************************************************
        /// </summary>
        static void DisplayDataRecorderMenuPrompt()
        {
            WriteLine();
            DisplayScreenHeader("Data Recorder");
            WriteLine("\tAt this screen, you can access ways to obtain temperature and light values from around the Finch Robot.");
        }

        static void DisplayDataTypeSelectionPrompt(string dataType)
        {
            DisplayScreenHeader(dataType);
            WriteLine("\tWelcome to the " + dataType + " screen.");
            WriteLine("\tHere, you will be able to access data for the " + dataType + " around your Finch Robot.");
        }

        /// <summary>
        /// *****************************************************************
        /// *                    Alarm System Screens                       *
        /// *****************************************************************
        /// </summary>

        static void DisplayAlarmMenuPrompt()
        {
            DisplayScreenHeader("Alarm System");
            WriteLine("\tWelcome to the alarm system process.");
            WriteLine("\tHere, you will be able to monitor light and temperature, and set an alarm if their values are too high or too low.");
            WriteLine();
        }

        static void DisplayMonitorPrompt()
        {
            DisplayScreenHeader("Alarm System");
            WriteLine("\tIn a moment, the Finch Robot will begin to monitor its surroundings.");
            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                         Prompts                               *
        /// *****************************************************************
        /// </summary>
        static void DisplayContinuePrompt()
        {
            WriteLine();
            WriteLine("\tPress any key to continue.");
            ReadKey(intercept: true);
        }

        static void DisplayTryAgainPrompt()
        {
            //  displays the "please try again" prompt
            //  only shown if the user didn't use ENTER or ESC on connection screens
            WriteLine("\tNext time you go to the connection or disconnection screens, only use ENTER or ESC!");
            WriteLine("\tPlease try again later.");
        }

        static void DisplayMenuPrompt(string menuName)
        {
            WriteLine();
            WriteLine($"\tPress any key to return to the {menuName}.");
            ReadKey();
        }

        static void DisplayScreenHeader(string headerText)
        {
            Clear();
            WriteLine();
            WriteLine("\t" + headerText);
            WriteLine();
        }

        static bool GeneralConfirmation()
        {
            WriteLine("\tPress ENTER if so. Press ESC otherwise.");
            ConsoleKeyInfo keyCode;
            do
            {
                keyCode = ReadKey(intercept: true);
                if (keyCode.Key == ConsoleKey.Enter)
                {
                    return true;
                }
                if (keyCode.Key == ConsoleKey.Escape)
                {
                    return false;
                }
                else
                {
                    WriteLine("\tYou entered " + keyCode.Key + ".");
                    WriteLine("\tPlease only press ENTER or ESC next time.");
                    DisplayContinuePrompt();
                    return false;
                }

            } while (keyCode.Key != ConsoleKey.Escape && keyCode.Key != ConsoleKey.Enter);
        }

        #endregion

        #region SOUND CONFIRMATIONS
        static void ConnectionDoneSound(Finch finchRobot)
        {
            finchRobot.noteOn(262);
            finchRobot.wait(500);
            finchRobot.noteOn(523);
            finchRobot.wait(500);
            finchRobot.noteOn(1046);
            finchRobot.wait(900);
            finchRobot.noteOff();
        }

        static void DisconnectionDoneSound(Finch finchRobot)
        {
            finchRobot.noteOn(262);
            finchRobot.wait(500);
            finchRobot.noteOn(131);
            finchRobot.wait(500);
            finchRobot.noteOn(65);
            finchRobot.wait(900);
            finchRobot.noteOff();
        }
        #endregion

        #region REFERENCES

        //For how the console key objects and characters work.
        //https://docs.microsoft.com/en-us/dotnet/api/system.console.readkey?view=netframework-4.8#System_Console_ReadKey_System_Boolean

        //For the console key number codes. These can already be found by typing in numbers behind 'Key.', but it's helpful to have the whole list to go through.
        //https://docs.microsoft.com/en-us/dotnet/api/system.consolekey?view=netframework-4.8

        //Note frequencies chart.
        //https://pages.mtu.edu/~suits/notefreqs.html

        //Color codes retrieved from this color wheel creator.
        //https://color.adobe.com/create/color-wheel/

        #endregion
    }
}
