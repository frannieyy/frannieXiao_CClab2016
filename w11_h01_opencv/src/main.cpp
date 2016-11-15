#include <iostream>
#include "opencv2/highgui/highgui.hpp"
#include "opencv2.imgproc/imgproc.hpp"
#include "opencv2/core/core.hpp"

//========================================================================

using namespace cv;

int main( ){
    
    VideoCapture cap(0);
    
    if(!cap.isOpened()){
        cout << "Webcam is not open." << endl;
    }
    
    while(true){
        Mat image;
        Mat HSVimage;
        Mat processedImage;
        
        cap.read(image);
        cvtColor(image, HSVimage, CV_BGR2HSV);
        inRange(HSVimage, Scaler(0,0,0), Scaler(100,255,255), processedImage);
        
        imshow("Original", image);
        imshow("Processed", processedImage);
    }

}
