import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AnalogueClockComponent } from './analogue-clock.component';

describe('AnalogueClockComponent', () => {
  let component: AnalogueClockComponent;
  let fixture: ComponentFixture<AnalogueClockComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AnalogueClockComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AnalogueClockComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
