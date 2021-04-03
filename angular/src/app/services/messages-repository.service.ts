import { Injectable } from '@angular/core';
import { Observable, of, Subject } from 'rxjs';
import { IMessage } from '../models/IMessage';
import { FileMessagesService } from './file-messages.service';
import { ImageMessagesService } from './image-messages.service';
import { TextMessagesService } from './text-messages.service';

@Injectable({
  providedIn: 'root'
})
export class MessagesRepositoryService {

  private _messages: IMessage[] = [];

  messages : Subject<IMessage[]> = new Subject<IMessage[]>();


  constructor(
    private fileMessageService: FileMessagesService,
    private textMessageService: TextMessagesService,
    private imageMessageService: ImageMessagesService) {
    this.loadAllData();
  }

  private async loadAllData() {
     
    let tempTextMessages = await this.textMessageService.getAllTextMessages();
    let tempFileMessages = await this.fileMessageService.getAllFileMessages();
    let tempImgMessages = await this.imageMessageService.getAllImageMessages();

    tempFileMessages.forEach((file) => {
      this._messages.push(file);
    })
    tempTextMessages.forEach((text) => {
      this._messages.push(text);
    })
    tempImgMessages.forEach((img) => {
      this._messages.push(img);
    })

    this._messages.sort((a, b) => <any>new Date(a.creationTime) - <any>new Date(b.creationTime));

    this.messages.next(this._messages);
  }

  addMessage(message: IMessage) {
    console.log(message);
    this._messages.push(message);
    this.messages.next(this._messages);
  }

  deleteMessage(message: IMessage) {
    let index = this._messages.findIndex((el) => el.id == message.id && el.type == message.type);
    this._messages.splice(index, 1);
    this.messages.next(this._messages);
  }

}
