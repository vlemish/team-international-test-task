import { Component, OnInit } from '@angular/core';
import { faEllipsisV, faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';
@Component({
  selector: 'app-text-message',
  templateUrl: './text-message.component.html',
  styleUrls: ['./text-message.component.css']
})
export class TextMessageComponent implements OnInit {

  constructor() { }

  dropDownIcon = faEllipsisV;
  trashIcon = faTrash;
  editIcon = faEdit;

  dropDownClass: string = "dropdown-list hidden"
  editabeContentClass: string = "hidden";
  staticContentClass: string = "";

  content: string = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod temporncididunt" + 
  "ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.";

  onShowMoreOver() {
    this.dropDownClass = "dropdown-list";
  }

  onShowMoreOut(){
    this.dropDownClass = "dropdown-list hidden";
  }

  onEditClick() {
    this.editabeContentClass = "";
    this.staticContentClass = "hidden";
  }

  onDeleteClick() {
    //some logic...
  }

  onSaveClick() {
    this.editabeContentClass = "hidden";
    this.staticContentClass = "";
  }

  onTextAreaChange(event: any) {
    this.content += event.target.value;
  }

  ngOnInit(): void {
  }

}
