import { Component, OnInit, AfterViewInit, ElementRef, ViewChild } from '@angular/core';
import { LocaltimeService } from '../../services/localtime.service'

@Component({
  selector: 'app-clock',
  templateUrl: './clock.component.html',
  styleUrls: ['./clock.component.css']
})
export class ClockComponent implements OnInit {

  private localTime: LocaltimeService;

  public rotateZ_hour: any;
  public rotateZ_minutes: any;
  public rotateZ_seconds: any;

  public rotateZ2: any;
  public bgcol: string = 'red';

  @ViewChild("minutescontainer", null) divView: ElementRef;

  constructor(svr: LocaltimeService) {
    this.localTime = svr;
  }

  ngAfterViewInit() {

    //console.log('bbbb' + this.divView.nativeElement);
    //console.log('bbbb' + this.divView.nativeElement);
    //this.divView.nativeElement.innerHTML = "Hello Angular 9!";

  }

  ngOnInit() {

    //60000

    this.initLocalClocks();
    //this.setUpMinuteHands();

    this.updateClock();
  }

  /*
 * Starts any clocks using the user's local time
 * From: cssanimation.rocks/clocks
 */
  initLocalClocks() {

    var localtime = this.localTime.currentTime();
    console.log(localtime);

    // Get the local time using JS
    //var date = new Date;

    var seconds = localtime.split(":")[2];
    var minutes = localtime.split(":")[1];
    var hours = localtime.split(":")[0];

    //console.log(seconds);
    //console.log(parseInt(seconds) * 6);

    // Create an object with each hand and it's angle in degrees
    var hands = [
      {
        hand: 'hours',
        angle: (parseInt(hours) * 30) + (parseInt(minutes) / 2)
      },
      {
        hand: 'minutes',
        angle: (parseInt(minutes) * 6)
      },
      {
        hand: 'seconds',
        angle: (parseInt(seconds) * 6)
      }
    ];

    this.rotateZ_hour = 'rotateZ(' + hands[0].angle + 'deg)';
    this.rotateZ_minutes = 'rotateZ(' + hands[1].angle + 'deg)';
    this.rotateZ_seconds = 'rotateZ(' + hands[2].angle + 'deg)';


  }


  updateClock() {
    setInterval(() => {
      this.initLocalClocks();
    }, 1000);
  }

  /*
 * Set a timeout for the first minute hand movement (less than 1 minute), then rotate it every minute after that
 */
  setUpMinuteHands() {

    console.log('here');

    //var x = this.divView.nativeElement;

    // Find out how far into the minute we are
    var containers = document.querySelectorAll('.minutes-container');
    console.log('grrr' + containers[0]);
    console.log('grrr' + containers[0].getAttribute("data-second-angle"));
    console.log('grrr' + containers[0].getAttributeNames());



    var secondAngle: number = +containers[0].getAttribute("data-second-angle");

    //console.log('here 22 ' + secondAngle);

    if (secondAngle > 0) {
      // Set a timeout until the end of the current minute, to move the hand
      var delay = (((360 - secondAngle) / 6) + 0.1) * 1000;
      setTimeout(function () {
        this.moveMinuteHands(containers);
      }, delay);
    }
  }

  /*
   * Do the first minute's rotation
   */
  moveMinuteHands(containers) {
    console.log(containers);
    for (var i = 0; i < containers.length; i++) {
      containers[i].style.webkitTransform = 'rotateZ(6deg)';
      containers[i].style.transform = 'rotateZ(6deg)';
    }
    // Then continue with a 60 second interval
    setInterval(function () {
      for (var i = 0; i < containers.length; i++) {
        if (containers[i].angle === undefined) {
          containers[i].angle = 12;
        } else {
          containers[i].angle += 6;
        }
        containers[i].style.webkitTransform = 'rotateZ(' + containers[i].angle + 'deg)';
        containers[i].style.transform = 'rotateZ(' + containers[i].angle + 'deg)';
        //console.log('here');
      }
    }, 60); //60000
  }
}
