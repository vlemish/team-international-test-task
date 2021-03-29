import { Component, ElementRef, OnDestroy, OnInit } from '@angular/core';
import { faCaretUp, faCaretDown } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-saved-messages',
  templateUrl: './saved-messages.component.html',
  styleUrls: ['./saved-messages.component.css']
})
export class SavedMessagesComponent implements OnInit, OnDestroy {

  constructor(private elementRef: ElementRef) { }

  messagesCount: number = 0;

  faCaret = faCaretUp;

  contentClass :string = "content"

  ngOnInit(): void {
    this.elementRef.nativeElement.ownerDocument.body.style.backgroundColor = 'lightgray';
  }
  ngOnDestroy(): void {
    this.elementRef.nativeElement.ownerDocument.body.style.backgroundColor = 'white';
  }

  onShowChange() {
    if (this.faCaret == faCaretUp) {
      this.faCaret = faCaretDown;
      this.messagesCount = 2;
      this.contentClass = "content hidden"
    }
    else {
      this.faCaret = faCaretUp;
      this.messagesCount = 0;
      this.contentClass = "content"
    }
  }

}
