import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlowerEditorComponent } from './flower-editor.component';

describe('FlowerEditorComponent', () => {
  let component: FlowerEditorComponent;
  let fixture: ComponentFixture<FlowerEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FlowerEditorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FlowerEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
