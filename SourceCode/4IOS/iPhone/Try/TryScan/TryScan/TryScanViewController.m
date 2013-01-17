//
//  TryScanViewController.m
//  TryScan
//
//  Created by yeetong on 12-12-19.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import "TryScanViewController.h"
#import "ZBarSDK/ZBarReaderController.h"

@interface TryScanViewController ()

@end

@implementation TryScanViewController
@synthesize txtResult;

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
}

- (void)viewDidUnload
{
    [self setTxtResult:nil];
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation != UIInterfaceOrientationPortraitUpsideDown);
}

- (IBAction)btnScan:(id)sender {
    ZBarReaderViewController *reader = [ZBarReaderViewController new];
    
    reader.readerDelegate = self;
    ZBarImageScanner *scanner = reader.scanner;
    
    [scanner setSymbology: ZBAR_I25
                   config: ZBAR_CFG_ENABLE
                       to: 0];
    [self presentModalViewController: reader
                            animated: YES];
}
- (void) imagePickerController: (UIImagePickerController*) reader
 didFinishPickingMediaWithInfo: (NSDictionary*) info
{
    id<NSFastEnumeration> results =
    [info objectForKey: ZBarReaderControllerResults];
    ZBarSymbol *symbol = nil;
    for(symbol in results)
        break;
    
    self.txtResult.text = symbol.data;
    
    [reader dismissModalViewControllerAnimated: YES];
}
@end
