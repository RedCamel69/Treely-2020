import { Injectable } from '@angular/core';
import {
  HttpClientJsonpModule, HttpClient, HttpHeaders
} from '@angular/common/http';
import { Observable } from 'rxjs';
//import 'rxjs/add/operator/catch';

@Injectable()
export class SearchService {

  constructor(private http: HttpClient) { }




  wikipediaSearch(searchPhrase: string) {

    const headers = new HttpHeaders({ 'contentType': 'application/json; charset=utf-8', 'async': 'false', 'datatype': 'json' });

    var res = this.http.jsonp(
      //url: "https://en.wikipedia.org/w/api.php?action=query&prop=extracts&exintro&explaintext&format=json&redirects&titles=Tom_Cruise&callback=?",
      'https://en.wikipedia.org/w/api.php?action=query&prop=extracts&exintro&explaintext&format=json&redirects&titles=' + searchPhrase + '&callback=?',
      'callback'
      //'https://api.cognitive.microsoft.com/bing/v7.0/search?q=' + encodeURI(searchPhrase) + '&mkt=en-gb&count=' + count + '&offset=' + offset,
      //{ headers: headers }
    );

    return res;
  }


  apisearch(searchPhrase: string, count: number, offset: number) {

    console.log("/apisearch" + "?query=" + encodeURI(searchPhrase) + '&mkt=en-gb&count=' + count + '&offset=' + offset);

    return this.http.get(
      "/apisearch" + "?query=" + encodeURI(searchPhrase) + '&mkt=en-gb&count=' + count + '&offset=' + offset
    )
     // .pipe(() =>{console.log("error!")});
    

    //console.log('grrr' + res);
   // return res;
  }

}
