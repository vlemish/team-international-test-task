import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { faEllipsisV, faFile, faTrash } from '@fortawesome/free-solid-svg-icons';
import { FileMessage } from 'src/app/models/FileMessage';
import { FileMessagesService } from 'src/app/services/file-messages.service';
import * as FileSaver from 'file-saver';
import { MessagesRepositoryService } from 'src/app/services/messages-repository.service';

@Component({
  selector: 'app-file-message',
  templateUrl: './file-message.component.html',
  styleUrls: ['./file-message.component.css']
})
export class FileMessageComponent implements OnInit {

  constructor(
    private fileService: FileMessagesService,
    private filesRepository: MessagesRepositoryService) { }

  dropDownIcon = faEllipsisV;
  trashIcon = faTrash;
  fileIcon = faFile;

  dropDownClass: string = "dropdown-list hidden"
  editabeContentClass: string = "hidden";
  staticContentClass: string = "";

  @Input() fileMessage: FileMessage = new FileMessage();

  getFileName() {
    if (this.fileMessage.name.length > 15) {
      return this.fileMessage.name.slice(0, 13) + '...';
    }
    return this.fileMessage.name;
  }

  ngOnInit(): void {
  }

  canEdit(): boolean {
    let dateToday = new Date(Date.now());
    let dateCreation = new Date(this.fileMessage.creationTime);
    let diffDate = dateToday.getDate() - dateCreation.getDate();

    // if the day is today check hours and minutes
    if (diffDate === 0) {
      let currentHours = new Date(Date.now()).getHours();
      let creationHours = new Date(this.fileMessage.creationTime).getHours();
      let currentMinutes = new Date(Date.now()).getMinutes();
      let creationMinutes = new Date(this.fileMessage.creationTime).getMinutes();
      let diffHours = currentHours - creationHours;
      let diffMin = currentMinutes - creationMinutes;
      if (diffHours !== 0 || Math.abs(diffMin) >= 15) {
        return true;
      }
      else {
        return false;
      }
    }
    return true;
  }

  onDownloadClick() {
    this.fileService.downloadFile(this.fileMessage.id).subscribe(
      (response: Blob) => {
        let fileName = this.fileMessage.name;
        let dataType = this.fileMessage.contentType;
        let binaryData = [];
        binaryData.push(response);
        let downloadLink = document.createElement('a');
        downloadLink.href = window.URL.createObjectURL(new Blob(binaryData, { type: dataType }));
        // FileSaver.saveAs(response, this.fileMessage.contentType);
        if (fileName)
          downloadLink.setAttribute('download', fileName);
        document.body.appendChild(downloadLink);
        downloadLink.click();
      },
      (error) => {
        console.log(error.message);
      }
    );
  }

  onShowMoreOver() {
    this.dropDownClass = "dropdown-list";
  }

  onShowMoreOut() {
    this.dropDownClass = "dropdown-list hidden";
  }

  onDeleteClick() {
    if (this.canEdit()) {
      this.fileService.deleteFileMessage(this.fileMessage.id).subscribe(
        () => {
          this.filesRepository.deleteMessage(this.fileMessage);
        },
        (error) => {

        });
    }
    else {
      window.alert('You can delete the file only in 15 minutes after creating!');
    }
  }
}