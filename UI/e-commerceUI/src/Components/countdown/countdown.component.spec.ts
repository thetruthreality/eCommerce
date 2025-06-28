import { ComponentFixture, TestBed, fakeAsync, tick } from '@angular/core/testing';
import { CountdownComponent } from './countdown.component';

describe('CountdownComponent', () => {
  let component: CountdownComponent;
  let fixture: ComponentFixture<CountdownComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CountdownComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CountdownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should start countdown on init', fakeAsync(() => {
    component.count = 3;
    component.ngOnInit();
    tick(1000);
    expect(component.count).toBe(2);
    tick(2000);
    expect(component.count).toBe(0);
  }));

  it('should stop countdown at zero', fakeAsync(() => {
    component.count = 1;
    component.ngOnInit();
    tick(1000);
    expect(component.count).toBe(0);
    tick(1000);
    expect(component.count).toBe(0);
  }));

  it('should clear interval on destroy', fakeAsync(() => {
    spyOn(window, 'clearInterval').and.callThrough();
    component.ngOnInit();
    component.ngOnDestroy();
    expect(clearInterval).toHaveBeenCalled();
  }));
});
