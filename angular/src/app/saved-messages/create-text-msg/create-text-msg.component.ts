import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { MessagesRepositoryService } from 'src/app/services/messages-repository.service';
import { TextMessagesService } from 'src/app/services/text-messages.service';

@Component({
  selector: 'app-create-text-msg',
  templateUrl: './create-text-msg.component.html',
  styleUrls: ['./create-text-msg.component.css']
})
export class CreateTextMsgComponent implements OnInit {

  constructor(
    private textService: TextMessagesService, 
    private filesRepository: MessagesRepositoryService) { }

  content : string = "";
  @Output() onComponentDone = new EventEmitter<number>();

  onContentChange(e : any){
    this.content += e.target.value;
  }

  onAddClicked(){     
    this.textService.addTextMessage(this.content).subscribe(
      (data)=>{     
        this.filesRepository.addMessage(data);
        this.onComponentDone.emit(1);
      },
      (error)=>{
        console.log('an error occured!');   
        this.onComponentDone.emit(1);     
      }
    );
  }

  onCancelClicked(){
    this.onComponentDone.emit(0);
    // do smth
  }

  ngOnInit(): void {
  }

}