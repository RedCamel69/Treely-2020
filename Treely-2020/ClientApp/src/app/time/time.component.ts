import { Component, OnInit } from '@angular/core';

declare var SunCalc: any;

@Component({
  selector: 'app-time',
  templateUrl: './time.component.html',
  styleUrls: ['./time.component.css']
})
export class TimeComponent implements OnInit {

  

  time: string;

  dusk: string;
  dawn: string;
  sunset: string;
  sunsetstart: string;
  goldenhour: string;
  solarnoon: string;
  sunrise: string;


  constructor() {
  }

  ngOnInit() {

   

    // get today's sunlight times for London
    var times = SunCalc.getTimes(new Date(), 51.5, -0.1);
    console.log(times);

    this.dusk = times.dusk.toString().substring(0,25);
    this.dawn = times.dawn.toString().substring(0, 25);
    this.sunrise = times.sunrise.toString().substring(0, 25);
    this.goldenhour = times.goldenHour.toString().substring(0, 25);
    this.solarnoon = times.solarNoon.toString().substring(0, 25);


    this.startTime();

  }

  checkTime(i) {
   // console.log('CHECKTIME');
    if (i < 10) { i = "0" + i };  // add zero in front of numbers < 10
    return i;
  }

  startTime() {
   // console.log('here');
    var today = new Date();
    var h = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();
    m = this.checkTime(m);
    s = this.checkTime(s);
    this.time = h + ":" + m + ":" + s;

    //var t = setTimeout(this.startTime, 500);
    //setTimeout(() => {    //<<<---    using ()=> syntax
    //  this.startTime;
    //}, 500);

    setInterval(() => {
     // console.log("hello");
      this.startTime();
    }, 1000);
  }


  }

  


