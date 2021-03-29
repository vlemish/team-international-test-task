import { Component, OnInit } from '@angular/core';
import { faEllipsisV, faFile, faTrash } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-file-message',
  templateUrl: './file-message.component.html',
  styleUrls: ['./file-message.component.css']
})
export class FileMessageComponent implements OnInit {

  constructor() { }

  dropDownIcon = faEllipsisV;
  trashIcon = faTrash;
  fileIcon = faFile;

  dropDownClass: string = "dropdown-list hidden"
  editabeContentClass: string = "hidden";
  staticContentClass: string = "";

  ngOnInit(): void {
  }

  onDownloadClick(){
    //act...
  }

  onShowMoreOver() {
    this.dropDownClass = "dropdown-list";
  }

  onShowMoreOut(){
    this.dropDownClass = "dropdown-list hidden";
  }

  onDeleteClick() {
    //some logic...
  }
}
