import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { faEllipsisV, faTrash } from '@fortawesome/free-solid-svg-icons';
import { ImageMessage } from 'src/app/models/ImageMessage';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { FileMessagesService } from 'src/app/services/file-messages.service';
import { ImageMessagesService } from 'src/app/services/image-messages.service';

@Component({
  selector: 'app-img-message',
  templateUrl: './img-message.component.html',
  styleUrls: ['./img-message.component.css']
})
export class ImgMessageComponent implements OnInit {

  constructor(
    private sanitizer: DomSanitizer,
    private imgService: ImageMessagesService) { }

  dropDownIcon = faEllipsisV;
  trashIcon = faTrash;

  headerClass: string = "msg-header hidden";
  footerClass: string = "msg-footer hidden";
  dropDownClass: string = "dropdown-list hidden"
  editabeContentClass: string = "hidden";
  staticContentClass: string = "";


  @Input() imgMessage: ImageMessage = new ImageMessage();
  @Output() componentUpdated = new EventEmitter();

  imgUrl: SafeUrl = "";

  extractImage() {
    let url = 'data:' + this.imgMessage.contentType + ';base64,' + this.imgMessage.data;
    this.imgUrl = this.sanitizer.bypassSecurityTrustUrl(url);
  }

  getFileName() {
    if (this.imgMessage.name.length > 15) {
      return this.imgMessage.name.slice(0, 13) + '...';
    }
    return this.imgMessage.name;
  }

  canEdit(): boolean {
    let dateToday = new Date(Date.now());
    let dateCreation = new Date(this.imgMessage.creationTime);
    let diffDate = dateToday.getDate() - dateCreation.getDate();

    // if the day is today check hours and minutes
    if (diffDate === 0) {
      let currentHours = new Date(Date.now()).getHours();
      let creationHours = new Date(this.imgMessage.creationTime).getHours();
      let currentMinutes = new Date(Date.now()).getMinutes();
      let creationMinutes = new Date(this.imgMessage.creationTime).getMinutes();      
      let diffHours = currentHours - creationHours;
      let diffMin = currentMinutes - creationMinutes;
      if (diffHours !== 0 || Math.abs(diffMin) >= 15) {
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

  onImgMouseOver() {
    this.headerClass = "msg-header"
    this.footerClass = "msg-footer"
  }

  onImgMouseOut() {
    this.headerClass = "msg-header hidden"
    this.footerClass = "msg-footer hidden"
  }

  ngOnInit(): void {
    this.extractImage();
  }

  onDeleteClick() {
    if (this.canEdit()) {
      this.imgService.deleteImageMessage(this.imgMessage.id).subscribe(
        () => {
          this.componentUpdated.emit();
        },
        (error) => {

        }
      );
    }
    else {
      window.alert('You can delete the file only in 15 minutes after creating!');
    }
  }

}