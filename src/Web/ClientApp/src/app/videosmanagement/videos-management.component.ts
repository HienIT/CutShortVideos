import { Component } from '@angular/core';
import { RawVideosClient, RawVideoDto } from '../web-api-client';

@Component({
  selector: 'videos-management',
  templateUrl: './videos-management.component.html',
  styleUrls: ['./videos-management.component.scss']
})
export class VideosManagementComponent {
  public rawVideos: RawVideoDto[] = [];

  constructor(private client: RawVideosClient) {
    client.getRawVideosWithPagination().subscribe({
      next: result => this.rawVideos = result,
      error: error => console.error(error)
    });
  }
}
