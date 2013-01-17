//
//  ContactMe.m
//  TryStoryboards
//
//  Created by yeetong on 12-10-4.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import "ContactMe.h"

@interface ContactMe ()

@end

@implementation ContactMe
@synthesize ImageTry;

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view.
    
    NSURL *url=[NSURL URLWithString:@"http://www.pcbeta.com/static/image/icon/article/windowsphone.png"];
    NSData *data=[NSData dataWithContentsOfURL:url];
    ImageTry.image=[[UIImage alloc] initWithData:data];
    
}

- (void)viewDidUnload
{
    [self setImageTry:nil];
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation == UIInterfaceOrientationPortrait);
}

@end
