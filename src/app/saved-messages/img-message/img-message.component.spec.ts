import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImgMessageComponent } from './img-message.component';

describe('ImgMessageComponent', () => {
  let component: ImgMessageComponent;
  let fixture: ComponentFixture<ImgMessageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImgMessageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ImgMessageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
