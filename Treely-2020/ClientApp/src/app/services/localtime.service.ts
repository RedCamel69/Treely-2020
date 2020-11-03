import { Injectable } from '@angular/core';



@Injectable({

  providedIn: 'root'

})

export class LocaltimeService {



  constructor() { }





  public currentTime() {

    var d = this.checkTime;

    var today = new Date();

    var h = today.getHours();

    var m = today.getMinutes();

    var s = today.getSeconds();

    m = d(m);

    s = d(s);

    return h + ":" + m + ":" + s;



  }



  private checkTime(i) {

    if (i < 10) { i = "0" + i };  // add zero in front of numbers < 10

    return i;

  }



}
