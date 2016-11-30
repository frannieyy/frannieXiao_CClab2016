//
//  Particle.cpp
//  myEnergeticSketch
//
//  Created by yy on 2016/11/29.
//
//

#include "Particle.hpp"

// using the constructor to initialize all the variables
Particle::Particle(ofVec2f position) :
mPosition(position),
mVelocity(ofRandom(-2.f, 2.f), ofRandom(-2.f, 2.f)),
mAcceleration(ofVec2f(0)),
mLifeSpan(START),
{
    
}
//-------------------------------------
void Particle::applyForce(ofVec2f force)
{
    // adding for to acceleration
    mAcceleration += force;
}
//-------------------------------------
void Particle::update(float multiplier)
{
    // apply accelearation to velocity
    mVelocity += mAcceleration;
    mPosition += mVelocity * multiplier;
    
    // decreasing the particle life
    if (mLifeSpan > 0){
        mLifeSpan -= 1.f;
    }
    
}
//-------------------------------------
void Particle::draw()
{
    if( mLifeSpan > 100 ){
        // new born partilce will be brighter
        ofSetColor(mLifeSpan);
    }else if( mLifeSpan <= 1000 ){
        // do some sparkle!
        ofSetColor(ofRandom(0, (myLifeSpan/2)*255),ofRandom(0,(myLifeSpan/2)*255,ofRandom(0,myLifeSpan/2)*255));
    };
    
    // closer particle is smaller
    ofDrawCircle(mPosition, ofMap(mLifeSpan, 0, 120, 0, 5));
    
}
