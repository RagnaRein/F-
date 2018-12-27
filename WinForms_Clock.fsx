
//XML-doc header for Clock
///<summary> 
///The program creates a analog clock thorugh graphical user interface with Winforms. A window open showing an analog and a digital clock. 
///The hour hand is black, the minute hand blure and the second hand is red. 
///<\summary>
/// <param name= "e"> PaintEventArgs (a class)<\param>
///<remarks> Design has not been focused on, many improvements could be done in this area. And the code could have been structured better.
///Preferbly the code could have been split up into smaller elements, instead of being just one large chunk of code (Clock), and perhaps some definitions
/// could have been generlised more to make it easier to update. <\remarks> 
///<returns> A window with an analog clock. <\returns>

open System.Windows.Forms                                                            //opening relevant libraries/namespaces
open System.Drawing
open System

let clockWindow = new Form ()                                                         //making a window form 
clockWindow.BackColor <- Color.White                                                  //setting background colour to white
clockWindow.ClientSize <- Size (600, 600)                                             // setting window size 

let toInt = int << round                                                             // helper function to convert floats to integers (from Jon Sporrings book)
let mutable dateTime = DateTime.Now                                                  // getting the current date and time  

let Clock (e : PaintEventArgs) : unit =                                               //function for building and drawing the clock
    let pen1 = new Pen (Color.Black, 3.0F)                                            //black pen for hour hand and clock-face contour 
    let pen2 = new Pen (Color.Blue, 2.0F)                                             //blue pen for minute hand 
    let pen3 = new Pen (Color.Red, 1.0F)                                              //red pen for second hand 

    let hour = float (dateTime.Hour)                                                  // getting the current hour and turning it into float type 
    let minute = float (dateTime.Minute)                                              // getting the current minute and turning it into float type 
    let second = float (dateTime.Second)                                              // getting the current second and turning it into float type 

    let hourAngle = 2.0 * System.Math.PI * ((hour + (minute / 60.0)) / 12.0)          //Angle for the hour hand (size of rotation)
    let minuteAngle = 2.0 * System.Math.PI * ((minute + (second / 60.0)) / 60.0)      //angle for the minute hand 
    let secondAngle = 2.0 * System.Math.PI * (second / 60.0)                          //angle for the second hand 

    let centerPoint = new Point (250, 250)                                                                                                //circle center point 
    let hourPoint = new Point (toInt(250.0 + 250.0 * System.Math.Sin(hourAngle)), toInt(250.0 - 250.0 * System.Math.Cos(hourAngle)))      //end point for hour hand 
    let minPoint = new Point (toInt(250.0 + 250.0 * System.Math.Sin(minuteAngle)), toInt(250.0 - 250.0 * System.Math.Cos(minuteAngle)))   //end point for minute hand 
    let secPoint = new Point (toInt(250.0 + 250.0 * System.Math.Sin(secondAngle)), toInt(250.0 - 250.0 * System.Math.Cos(secondAngle)))   //end point for second hand (updates every second)
 
    let hourLine = [|centerPoint; hourPoint|]                            //hour hand  
    let minLine = [|centerPoint; minPoint|]                              //minute hand 
    let secLine = [|centerPoint; secPoint|]                              //second hand 

    e.Graphics.DrawEllipse (pen1, 0, 0, 500, 500)                        //drawing the clock            
    e.Graphics.DrawLines (pen1, hourLine)
    e.Graphics.DrawLines (pen2, minLine)
    e.Graphics.DrawLines (pen3, secLine)
clockWindow.Paint.Add Clock


let digiWatch = new Label ()                                              //creating a new label to show time digitally 
clockWindow.Controls.Add digiWatch                                           
digiWatch.Width <- 200 
digiWatch.Location <- Point (250, 550)                                    //placement of digital watch 
digiWatch.Text <- string DateTime.Now                                     //label shows current time 

let timer = new Timer ()                                                  //creating timer to run the clock 
timer.Interval <- 1000                                                    // create an event every 1000 millisecond 
timer.Enabled <- true                                                     // activiate the timer
timer.Tick.Add (fun a -> digiWatch.Text <- string DateTime.Now)           //update digital watch to current time every second 
timer.Tick.Add (fun c -> clockWindow.Invalidate())                        //Invalidate window to make it redraw the clock every second 
timer.Tick.Add (fun b -> dateTime <- DateTime.Now)                        //update input value for the hand angles to current time every second 

Application.Run clockWindow                                               //run applications 








