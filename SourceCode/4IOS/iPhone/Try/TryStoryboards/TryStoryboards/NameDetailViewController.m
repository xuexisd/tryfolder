//
//  NameDetailViewController.m
//  TryStoryboards
//
//  Created by yeetong on 12-9-28.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import "NameDetailViewController.h"

@interface NameDetailViewController ()

@end

@implementation NameDetailViewController

@synthesize NameLabel;
@synthesize lblName;

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
    [self SetPreviousLableName];
    
}

- (void)viewDidUnload
{
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation == UIInterfaceOrientationPortrait);
}

-(void)SetPreviousLableName
{
    NameLabel.text=[NSString stringWithFormat:@"%@, %@", lblName, @"欢迎你."];
}

@end
