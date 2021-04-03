import { Component, ElementRef, OnDestroy, OnInit } from '@angular/core';
import { faCaretUp, faCaretDown, faImage, faFolderOpen, faPlus, faPen } from '@fortawesome/free-solid-svg-icons';
import { FileMessage } from '../models/FileMessage';
import { TextMessage } from '../models/TextMessage';
import { FileMessagesService } from '../services/file-messages.service';
import { TextMessagesService } from '../services/text-messages.service';
import { IMessage } from '../models/IMessage';
import { ImageMessage } from '../models/ImageMessage';
import { ImageMessagesService } from '../services/image-messages.service';
import { MessagesRepositoryService } from '../services/messages-repository.service';
import { map, scan } from 'rxjs/operators';

@Component({
  selector: 'app-saved-messages',
  templateUrl: './saved-messages.component.html',
  styleUrls: ['./saved-messages.component.css']
})

export class SavedMessagesComponent implements OnInit, OnDestroy {

  constructor(
    private elementRef: ElementRef,
    private fileService: FileMessagesService,
    private textService: TextMessagesService,
    private imgService: ImageMessagesService,
    private filesRepository: MessagesRepositoryService) { }

  messagesCount: number = 0;

  faCaret = faCaretUp;
  addText = faPen
  attachImage = faImage;
  attachFile = faFolderOpen;
  addIcon = faPlus;

  contentClass: string = "content"
  addMessagesClass: string = "add-messages";
  createTxtMsgClass: string = "create-txt-msg hidden";

  files: IMessage[] = [];

  fileToUpload: any;

  ngOnInit(): void {
    this.elementRef.nativeElement.ownerDocument.body.style.backgroundColor = 'lightgray';
    this.filesRepository.messages.subscribe((data) => {
      this.files = data;
      this.messagesCount = this.files.length;
    });
  }
  ngOnDestroy(): void {
    this.elementRef.nativeElement.ownerDocument.body.style.backgroundColor = 'white';
  }

  castToTextMessage(file: IMessage): TextMessage {
    return file as TextMessage;
  }

  castToFileMessage(file: IMessage): FileMessage {
    return file as FileMessage;
  }

  castToImgMessage(file: IMessage): ImageMessage {
    return file as ImageMessage;
  }

  onAddTextClick() {
    this.addMessagesClass = "add-messages hidden";
    this.createTxtMsgClass = "create-txt-msg";
  }

  onCreateComponentDone(event: number) {
    this.addMessagesClass = "add-messages";
    this.createTxtMsgClass = "create-txt-msg hidden";
  }

  onFileChoose(e: any) {
    this.fileToUpload = e.target.files[0];
    this.addFile();
  }

  onImageChoose(e: any) {
    this.fileToUpload = e.target.files[0];
    this.addImage();
  }

  addFile() {
    let form = new FormData();
    form.append('file', this.fileToUpload)
    this.fileService.addFileMessage(form).subscribe(
      (file) => {
        console.log(file);
        this.filesRepository.addMessage(file);
      },
      (error) => {

      }
    );
  }

  addImage() {
    let form = new FormData();
    form.append('file', this.fileToUpload)
    this.imgService.addImageMessage(form).subscribe(
      (image) => {
        console.log(image);
        this.filesRepository.addMessage(image);
      },
      (error) => {

      }
    );
  }

  onShowChange() {
    if (this.faCaret == faCaretUp) {
      this.faCaret = faCaretDown;
      this.contentClass = "content hidden"
    }
    else {
      this.faCaret = faCaretUp;
      this.contentClass = "content"
    }
  }

}
