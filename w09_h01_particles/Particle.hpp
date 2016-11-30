//
//  Particle.hpp
//  myEnergeticSketch
//
//  Created by yy on 2016/11/29.
//
//

#pragma once
#include "ofMain.h"

class Particle{
public:
    // creating a constructor
    Particle(ofVec2f pos);
    
    void resetForces();
    void applyForce(ofVec2f force);
    void update(float multiplier);
    void draw();
    
    ofVec2f mPosition, mVelocity, mAcceleration;
    float mLifeSpan;
    const float START = 120.0F;
};
