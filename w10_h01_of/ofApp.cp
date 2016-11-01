#include "ofApp.h"

//--------------------------------------------------------------
void ofApp::setup(){
    nPts = 0;
    
}

//--------------------------------------------------------------
void ofApp::update() {
    
}

//--------------------------------------------------------------
void ofApp::draw(){
    if (nPts>1){
        for(int i= 0; i < nPts -1; i++){
            ofDrawLine(pts[i].x, pts[i].y, pts[i+1].x, pts[i+1].y);
        }
    }
}

//--------------------------------------------------------------
void ofApp::keyPressed(int key){
    if (key == OF_KEY_RETURN){
        nPts = 0;
    }
}

//--------------------------------------------------------------
void ofApp::keyReleased(int key){
    
}

//--------------------------------------------------------------
void ofApp::mouseMoved(int x, int y ){
    
}

//--------------------------------------------------------------
void ofApp::mouseDragged(int x, int y, int button){
    if (nPts < MAX_PTS){
        pts[nPts].x = x;
        pts[nPts].y = y;
        nPts++;
    }
}

//--------------------------------------------------------------
void ofApp::mousePressed(int x, int y, int button){
    ofSetColor(x, y, 20);
}

//--------------------------------------------------------------
void ofApp::mouseReleased(int x, int y, int button){
    
}

//--------------------------------------------------------------
void ofApp::windowResized(int w, int h){
    
}
