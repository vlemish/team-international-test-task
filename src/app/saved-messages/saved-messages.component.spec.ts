import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SavedMessagesComponent } from './saved-messages.component';

describe('SavedMessagesComponent', () => {
  let component: SavedMessagesComponent;
  let fixture: ComponentFixture<SavedMessagesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SavedMessagesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SavedMessagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
