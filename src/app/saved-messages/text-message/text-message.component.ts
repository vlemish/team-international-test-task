import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { faEllipsisV, faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';
import { TextMessage } from 'src/app/models/TextMessage';
import { TextMessagesService } from 'src/app/services/text-messages.service';

@Component({
  selector: 'app-text-message',
  templateUrl: './text-message.component.html',
  styleUrls: ['./text-message.component.css']
})
export class TextMessageComponent implements OnInit {

  constructor(private textService: TextMessagesService) { }

  dropDownIcon = faEllipsisV;
  trashIcon = faTrash;
  editIcon = faEdit;

  dropDownClass: string = "dropdown-list hidden"
  editabeContentClass: string = "hidden";
  staticContentClass: string = "";

  @Output() componentUpdated = new EventEmitter();

  @Input() txtMessage: TextMessage = new TextMessage();


  canEdit(): boolean {
    let dateToday = new Date(Date.now());
    let dateCreation = new Date(this.txtMessage.creationTime);
    let diffDate = dateToday.getDate() - dateCreation.getDate();

    //if the day is today check hours and minutes
    if (diffDate === 0) {
      let currentHours = new Date(Date.now()).getHours();
      let creationHours = new Date(this.txtMessage.creationTime).getHours();
      let currentMinutes = new Date(Date.now()).getMinutes();
      let creationMinutes = new Date(this.txtMessage.creationTime).getMinutes();

      let diffHours = currentHours - creationHours;
      let diffMin = currentMinutes - creationMinutes;
      if (diffHours !== 0 && diffMin >= 15) {
        return true;
      }
    }
    return false;
  }

  onShowMoreOver() {
    this.dropDownClass = "dropdown-list";
  }

  onShowMoreOut() {
    this.dropDownClass = "dropdown-list hidden";
  }

  onEditClick() {
    if (this.canEdit()) {
      this.editabeContentClass = "";
      this.staticContentClass = "hidden";
    }
    else {
      window.alert('You can edit the file only in 15 minutes after creating!');
    }
  }

  onDeleteClick() {
    if (this.canEdit()) {
      this.textService.deleteTextMessage(this.txtMessage.id).subscribe(
        () => {
          this.componentUpdated.emit();
        },
        (error) => {

        });
    }
    else {
      window.alert('You can delete the file only in 15 minutes after creating!');
    }
  }

  onSaveClick() {
    this.editabeContentClass = "hidden";
    this.staticContentClass = "";

    this.textService.updateTextMessage(this.txtMessage.id, this.txtMessage.content).subscribe(
      (data) => {
        this.componentUpdated.emit();
      },
      (error) => {

      }
    );
  }

  onTextAreaChange(event: any) {
    this.txtMessage.content = event.target.value;
  }

  ngOnInit(): void {
  }

}