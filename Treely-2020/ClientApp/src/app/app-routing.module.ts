import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SearchComponent } from '../app/search/search.component';
import { IndexComponent } from '../app/index/index.component';
import { AboutComponent } from '../app/about/about.component';
import { TimeComponent } from '../app/time/time.component';
import { AnalogueClockComponent } from './analogue-clock/analogue-clock.component';

const routes: Routes = [
  { path: 'search', component: SearchComponent },
  { path: 'index', component: IndexComponent },
  { path: 'about', component: AboutComponent },
  { path: 'time', component: TimeComponent },
  { path: 'analogueclock', component: AnalogueClockComponent },

  { path: '', component: IndexComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
