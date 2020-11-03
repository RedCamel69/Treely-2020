import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AutocompleteService {

  constructor(private http: HttpClient) { }

  autocomplete(term:string) {


    return this.http.get(
      "/apiautocomplete/?query=" + encodeURI(term)
    );

  }
}

