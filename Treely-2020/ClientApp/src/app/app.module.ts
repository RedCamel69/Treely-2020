import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IndexComponent } from './index/index.component';
import { SearchComponent } from './search/search.component';
import { AboutComponent } from './about/about.component';

import { SearchService } from '../services/search.service';
import { AutocompleteService } from '../services/autocomplete.service';

import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClientJsonpModule } from '@angular/common/http';
import { TimeComponent } from './time/time.component';
import { ClockComponent } from './shared/clock/clock.component';
import { AnalogueClockComponent } from './analogue-clock/analogue-clock.component';  // replaces previous Http service

@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    SearchComponent,
    AboutComponent,
    TimeComponent,
    ClockComponent,
    AnalogueClockComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    HttpClientJsonpModule
  ],
  providers: [SearchService, AutocompleteService],
  bootstrap: [AppComponent]
})
export class AppModule { }
