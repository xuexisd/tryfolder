//
//  GroupDetailListViewController.m
//  CloudContact
//
//  Created by yeetong on 12-11-2.
//  Copyright (c) 2012年 yeetong. All rights reserved.
//

#import "GroupDetailListViewController.h"
#import <AddressBook/AddressBook.h>
#import "pinyin.h"

@interface GroupDetailListViewController ()

@end

@implementation GroupDetailListViewController
{
    CFArrayRef personArray;
    ABAddressBookRef ababr;
    NSMutableArray *arraycurrentAllSection;
    NSMutableArray *arrayAllPerson;
    NSMutableArray *arrayPersonForA;
    NSMutableArray *arrayPersonForB;
    NSMutableArray *arrayPersonForC;
    NSMutableArray *arrayPersonForD;
    NSMutableArray *arrayPersonForE;
    NSMutableArray *arrayPersonForF;
    NSMutableArray *arrayPersonForG;
    NSMutableArray *arrayPersonForH;
    NSMutableArray *arrayPersonForI;
    NSMutableArray *arrayPersonForJ;
    NSMutableArray *arrayPersonForK;
    NSMutableArray *arrayPersonForL;
    NSMutableArray *arrayPersonForM;
    NSMutableArray *arrayPersonForN;
    NSMutableArray *arrayPersonForO;
    NSMutableArray *arrayPersonForP;
    NSMutableArray *arrayPersonForQ;
    NSMutableArray *arrayPersonForR;
    NSMutableArray *arrayPersonForS;
    NSMutableArray *arrayPersonForT;
    NSMutableArray *arrayPersonForU;
    NSMutableArray *arrayPersonForV;
    NSMutableArray *arrayPersonForW;
    NSMutableArray *arrayPersonForX;
    NSMutableArray *arrayPersonForY;
    NSMutableArray *arrayPersonForZ;
    NSMutableArray *arrayPersonForHash;
}
@synthesize groupRecord;
@synthesize lblShowRightAlphabet;
@synthesize tableViewAllPersonInGroup;


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
    
	[self.view addSubview:lblShowRightAlphabet];
    
    self.title = (__bridge NSString *)ABRecordCopyCompositeName(groupRecord);
    [self LoadCurrentGroupAllPerson];
}

- (void)viewDidUnload
{
    [self setTableViewAllPersonInGroup:nil];
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation == UIInterfaceOrientationPortrait);
}

-(void)LoadCurrentGroupAllPerson
{
    ababr=ABAddressBookCreate();
    ABRecordGetRecordID(groupRecord);
    if([self.title isEqualToString:@"所有联系人"])
    {
        personArray = ABAddressBookCopyArrayOfAllPeopleInSourceWithSortOrdering(ababr, nil, ABPersonGetSortOrdering());
    }
    else
    {
        personArray = ABGroupCopyArrayOfAllMembersWithSortOrdering(groupRecord, ABPersonGetSortOrdering());
    }
    
    arraycurrentAllSection = [[NSMutableArray alloc] init];
    arrayAllPerson = [[NSMutableArray alloc] init];
    arrayPersonForA = [[NSMutableArray alloc] init];
    arrayPersonForB = [[NSMutableArray alloc] init];
    arrayPersonForC = [[NSMutableArray alloc] init];
    arrayPersonForD = [[NSMutableArray alloc] init];
    arrayPersonForE = [[NSMutableArray alloc] init];
    arrayPersonForF = [[NSMutableArray alloc] init];
    arrayPersonForG = [[NSMutableArray alloc] init];
    arrayPersonForH = [[NSMutableArray alloc] init];
    arrayPersonForI = [[NSMutableArray alloc] init];
    arrayPersonForJ = [[NSMutableArray alloc] init];
    arrayPersonForK = [[NSMutableArray alloc] init];
    arrayPersonForL = [[NSMutableArray alloc] init];
    arrayPersonForM = [[NSMutableArray alloc] init];
    arrayPersonForN = [[NSMutableArray alloc] init];
    arrayPersonForO = [[NSMutableArray alloc] init];
    arrayPersonForP = [[NSMutableArray alloc] init];
    arrayPersonForQ = [[NSMutableArray alloc] init];
    arrayPersonForR = [[NSMutableArray alloc] init];
    arrayPersonForS = [[NSMutableArray alloc] init];
    arrayPersonForT = [[NSMutableArray alloc] init];
    arrayPersonForU = [[NSMutableArray alloc] init];
    arrayPersonForV = [[NSMutableArray alloc] init];
    arrayPersonForW = [[NSMutableArray alloc] init];
    arrayPersonForX = [[NSMutableArray alloc] init];
    arrayPersonForY = [[NSMutableArray alloc] init];
    arrayPersonForZ = [[NSMutableArray alloc] init];
    arrayPersonForHash = [[NSMutableArray alloc] init];
    
//    NSMutableArray *chineseStringsArray=[NSMutableArray array];
    for(int i=0;i<(CFArrayGetCount(personArray));i++)
    {
        //Remark: ChineseString only two arry is: [string] and [pinYin]
//        ChineseString *chineseString=[[ChineseString alloc]init];
//        chineseString.string=(__bridge NSString *)ABRecordCopyCompositeName(CFArrayGetValueAtIndex(personArray, i));
//        if(chineseString.string==nil)
//        {
//            chineseString.string=@"";
//        }
//        if(![chineseString.string isEqualToString:@""]){
//            NSString *pinYinResult=[NSString string];
//            for(int j=0;j<chineseString.string.length;j++){
//                NSString *singlePinyinLetter=[[NSString stringWithFormat:@"%c",pinyinFirstLetter([chineseString.string characterAtIndex:j])]uppercaseString];
//                NSLog(@"%@",singlePinyinLetter);
//                pinYinResult=[pinYinResult stringByAppendingString:singlePinyinLetter];
//            }
//            chineseString.pinYin=pinYinResult;
//        }else{
//            chineseString.pinYin=@"";
//        }
//        [chineseStringsArray addObject:chineseString];
        
        NSString *singlePinyinLetter=[[NSString stringWithFormat:@"%c",pinyinFirstLetter([(__bridge NSString *)ABRecordCopyCompositeName(CFArrayGetValueAtIndex(personArray, i)) characterAtIndex:0])]uppercaseString];
//        NSLog(@"%@",singlePinyinLetter);
        
        if([singlePinyinLetter isEqualToString:@"A"])
        {
            [arrayPersonForA addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"B"])
        {
            [arrayPersonForB addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"C"])
        {
            [arrayPersonForC addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"D"])
        {
            [arrayPersonForD addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"E"])
        {
            [arrayPersonForE addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"F"])
        {
            [arrayPersonForF addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"G"])
        {
            [arrayPersonForG addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"H"])
        {
            [arrayPersonForH addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"I"])
        {
            [arrayPersonForI addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"J"])
        {
            [arrayPersonForJ addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"K"])
        {
            [arrayPersonForK addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"L"])
        {
            [arrayPersonForL addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"M"])
        {
            [arrayPersonForM addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"N"])
        {
            [arrayPersonForN addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"O"])
        {
            [arrayPersonForO addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"P"])
        {
            [arrayPersonForP addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"Q"])
        {
            [arrayPersonForQ addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"R"])
        {
            [arrayPersonForR addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"S"])
        {
            [arrayPersonForS addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"T"])
        {
            [arrayPersonForT addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"U"])
        {
            [arrayPersonForU addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"V"])
        {
            [arrayPersonForV addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"W"])
        {
            [arrayPersonForW addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"X"])
        {
            [arrayPersonForX addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"Y"])
        {
            [arrayPersonForY addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if([singlePinyinLetter isEqualToString:@"Z"])
        {
            [arrayPersonForZ addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
        if(![singlePinyinLetter isEqualToString:@"A"]
           && ![singlePinyinLetter isEqualToString:@"B"]
           && ![singlePinyinLetter isEqualToString:@"C"]
           && ![singlePinyinLetter isEqualToString:@"D"]
           && ![singlePinyinLetter isEqualToString:@"E"]
           && ![singlePinyinLetter isEqualToString:@"F"]
           && ![singlePinyinLetter isEqualToString:@"G"]
           && ![singlePinyinLetter isEqualToString:@"H"]
           && ![singlePinyinLetter isEqualToString:@"I"]
           && ![singlePinyinLetter isEqualToString:@"J"]
           && ![singlePinyinLetter isEqualToString:@"K"]
           && ![singlePinyinLetter isEqualToString:@"L"]
           && ![singlePinyinLetter isEqualToString:@"M"]
           && ![singlePinyinLetter isEqualToString:@"N"]
           && ![singlePinyinLetter isEqualToString:@"O"]
           && ![singlePinyinLetter isEqualToString:@"P"]
           && ![singlePinyinLetter isEqualToString:@"Q"]
           && ![singlePinyinLetter isEqualToString:@"R"]
           && ![singlePinyinLetter isEqualToString:@"S"]
           && ![singlePinyinLetter isEqualToString:@"T"]
           && ![singlePinyinLetter isEqualToString:@"U"]
           && ![singlePinyinLetter isEqualToString:@"V"]
           && ![singlePinyinLetter isEqualToString:@"W"]
           && ![singlePinyinLetter isEqualToString:@"X"]
           && ![singlePinyinLetter isEqualToString:@"Y"]
           && ![singlePinyinLetter isEqualToString:@"Z"])
        {
            [arrayPersonForHash addObject:(__bridge id)(CFArrayGetValueAtIndex(personArray, i))];
        }
    }
    if(arrayPersonForA != nil && [arrayPersonForA count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForA];
        [arraycurrentAllSection addObject:@"A"];
//        NSLog(@"[A]:%@",[arrayPersonForA objectAtIndex:0]);
//        NSLog(@"CompositeName is :%@",(__bridge NSString *)ABRecordCopyCompositeName((__bridge ABRecordRef)[arrayPersonForA objectAtIndex:0]));
    }
    if(arrayPersonForB != nil && [arrayPersonForB count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForB];
        [arraycurrentAllSection addObject:@"B"];
    }
    if(arrayPersonForC != nil && [arrayPersonForC count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForC];
        [arraycurrentAllSection addObject:@"C"];
    }
    if(arrayPersonForD != nil && [arrayPersonForD count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForD];
        [arraycurrentAllSection addObject:@"D"];
    }
    if(arrayPersonForE != nil && [arrayPersonForE count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForE];
        [arraycurrentAllSection addObject:@"E"];
    }
    if(arrayPersonForF != nil && [arrayPersonForF count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForF];
        [arraycurrentAllSection addObject:@"F"];
    }
    if(arrayPersonForG != nil && [arrayPersonForG count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForG];
        [arraycurrentAllSection addObject:@"G"];
    }
    if(arrayPersonForH != nil && [arrayPersonForH count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForH];
        [arraycurrentAllSection addObject:@"H"];
    }
    if(arrayPersonForI != nil && [arrayPersonForI count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForI];
        [arraycurrentAllSection addObject:@"I"];
    }
    if(arrayPersonForJ != nil && [arrayPersonForJ count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForJ];
        [arraycurrentAllSection addObject:@"J"];
    }
    if(arrayPersonForK != nil && [arrayPersonForK count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForK];
        [arraycurrentAllSection addObject:@"K"];
    }
    if(arrayPersonForL != nil && [arrayPersonForL count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForL];
        [arraycurrentAllSection addObject:@"L"];
    }
    if(arrayPersonForM != nil && [arrayPersonForM count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForM];
        [arraycurrentAllSection addObject:@"M"];
    }
    if(arrayPersonForN != nil && [arrayPersonForN count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForN];
        [arraycurrentAllSection addObject:@"N"];
    }
    if(arrayPersonForO != nil && [arrayPersonForO count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForO];
        [arraycurrentAllSection addObject:@"O"];
    }
    if(arrayPersonForP != nil && [arrayPersonForP count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForP];
        [arraycurrentAllSection addObject:@"P"];
    }
    if(arrayPersonForQ != nil && [arrayPersonForQ count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForQ];
        [arraycurrentAllSection addObject:@"Q"];
    }
    if(arrayPersonForR != nil && [arrayPersonForR count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForR];
        [arraycurrentAllSection addObject:@"R"];
    }
    if(arrayPersonForS != nil && [arrayPersonForS count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForS];
        [arraycurrentAllSection addObject:@"S"];
    }
    if(arrayPersonForT != nil && [arrayPersonForT count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForT];
        [arraycurrentAllSection addObject:@"T"];
    }
    if(arrayPersonForU != nil && [arrayPersonForU count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForU];
        [arraycurrentAllSection addObject:@"U"];
    }
    if(arrayPersonForV != nil && [arrayPersonForV count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForV];
        [arraycurrentAllSection addObject:@"V"];
    }
    if(arrayPersonForW != nil && [arrayPersonForW count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForW];
        [arraycurrentAllSection addObject:@"W"];
    }
    if(arrayPersonForX != nil && [arrayPersonForX count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForX];
        [arraycurrentAllSection addObject:@"X"];
    }
    if(arrayPersonForY != nil && [arrayPersonForY count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForY];
        [arraycurrentAllSection addObject:@"Y"];
    }
    if(arrayPersonForZ != nil && [arrayPersonForZ count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForZ];
        [arraycurrentAllSection addObject:@"Z"];
    }
    if(arrayPersonForHash != nil && [arrayPersonForHash count]>0)
    {
        [arrayAllPerson addObject:arrayPersonForHash];
        [arraycurrentAllSection addObject:@"#"];
    }
}

-(NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    int currentSectionRows = 0;
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"A"])
    {
        currentSectionRows = [arrayPersonForA count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"B"])
    {
        currentSectionRows = [arrayPersonForB count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"C"])
    {
        currentSectionRows = [arrayPersonForC count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"D"])
    {
        currentSectionRows = [arrayPersonForD count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"E"])
    {
        currentSectionRows = [arrayPersonForE count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"F"])
    {
        currentSectionRows = [arrayPersonForF count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"G"])
    {
        currentSectionRows = [arrayPersonForG count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"H"])
    {
        currentSectionRows = [arrayPersonForH count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"I"])
    {
        currentSectionRows = [arrayPersonForI count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"J"])
    {
        currentSectionRows = [arrayPersonForJ count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"K"])
    {
        currentSectionRows = [arrayPersonForK count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"L"])
    {
        currentSectionRows = [arrayPersonForL count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"M"])
    {
        currentSectionRows = [arrayPersonForM count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"N"])
    {
        currentSectionRows = [arrayPersonForN count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"O"])
    {
        currentSectionRows = [arrayPersonForO count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"P"])
    {
        currentSectionRows = [arrayPersonForP count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"Q"])
    {
        currentSectionRows = [arrayPersonForQ count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"R"])
    {
        currentSectionRows = [arrayPersonForR count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"S"])
    {
        currentSectionRows = [arrayPersonForS count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"T"])
    {
        currentSectionRows = [arrayPersonForT count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"U"])
    {
        currentSectionRows = [arrayPersonForU count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"V"])
    {
        currentSectionRows = [arrayPersonForV count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"W"])
    {
        currentSectionRows = [arrayPersonForW count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"X"])
    {
        currentSectionRows = [arrayPersonForX count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"Y"])
    {
        currentSectionRows = [arrayPersonForY count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"Z"])
    {
        currentSectionRows = [arrayPersonForZ count];
    }
    if([[arraycurrentAllSection objectAtIndex:section] isEqualToString:@"#"])
    {
        currentSectionRows = [arrayPersonForHash count];
    }
    return currentSectionRows;
}

-(UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    static NSString *personTableIdentifier = @"PersonCell";
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:personTableIdentifier];
    if (cell == nil) {
        cell = [[UITableViewCell alloc]
                initWithStyle:UITableViewCellStyleDefault reuseIdentifier:personTableIdentifier];
    }
    
    
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"A"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForA), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"B"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForB), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"C"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForC), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"D"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForD), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"E"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForE), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"F"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForF), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"G"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForG), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"H"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForH), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"I"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForI), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"J"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForJ), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"K"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForK), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"L"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForL), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"M"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForM), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"N"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForN), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"O"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForO), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"P"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForP), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"Q"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForQ), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"R"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForR), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"S"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForS), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"T"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForT), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"U"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForU), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"V"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForV), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"W"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForW), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"X"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForX), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"Y"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForY), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"Z"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForZ), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    if([[arraycurrentAllSection objectAtIndex:[indexPath section]] isEqualToString:@"#"])
    {
        ABRecordRef personRecord = (ABRecordRef) CFArrayGetValueAtIndex((__bridge CFArrayRef)(arrayPersonForHash), indexPath.row);
        NSString *personName=(__bridge NSString *)ABRecordCopyCompositeName(personRecord);
        cell.textLabel.text = personName;
    }
    return cell;
}

-(NSInteger)numberOfSectionsInTableView:(UITableView *)tableView
{
    return [arrayAllPerson count];
}

-(NSString *)tableView:(UITableView *)tableView titleForHeaderInSection:(NSInteger)section
{
    return [arraycurrentAllSection objectAtIndex:section];
}

- (NSArray *)sectionIndexTitlesForTableView:(UITableView *)tableView
{
    return arraycurrentAllSection;
}
- (NSInteger)tableView:(UITableView *)tableView :(NSString *)title atIndex:(NSInteger)index
{
    NSInteger count = 0;
    for(NSString *character in arraycurrentAllSection)
    {
        if([character isEqualToString:title])
        {
            return count;
        }
        count ++;
    }
    return 0;
}

@end

//[TopicsTable setContentOffset:CGPointMake(0, promiseNum * 44 + Chapter * 20)];