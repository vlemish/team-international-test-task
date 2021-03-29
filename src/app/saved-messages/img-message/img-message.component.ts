import { Component, OnInit } from '@angular/core';
import { faBan } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-img-message',
  templateUrl: './img-message.component.html',
  styleUrls: ['./img-message.component.css']
})
export class ImgMessageComponent implements OnInit {

  constructor() { }

  deleteIcon = faBan;

  headerClass: string = "msg-header hidden";
  footerClass: string = "msg-footer hidden";

  onImgMouseOver() {
    this.headerClass = "msg-header"
    this.footerClass = "msg-footer"
  }

  onImgMouseOut() {
    this.headerClass = "msg-header hidden"
    this.footerClass = "msg-footer hidden" 
  }


  imgUrl: string = "https://pbs.twimg.com/media/EKHltAKVUAAWixb.jpg";

  ngOnInit(): void {
  }

  onDeleteClick() {
    //delete...

  }

}
