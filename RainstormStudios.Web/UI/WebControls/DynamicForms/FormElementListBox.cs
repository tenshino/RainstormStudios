﻿//  Copyright (c) 2008, Michael unfried
//  Email:  serbius3@gmail.com
//  All rights reserved.

//  Redistribution and use in source and binary forms, with or without modification, 
//  are permitted provided that the following conditions are met:

//  Redistributions of source code must retain the above copyright notice, 
//  this list of conditions and the following disclaimer. 
//  Redistributions in binary form must reproduce the above copyright notice, 
//  this list of conditions and the following disclaimer in the documentation 
//  and/or other materials provided with the distribution. 

//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
//  PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER 
//  REMAINS UNCHANGED.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RainstormStudios.Web.UI.WebControls.DynamicForms
{
    public class FormElementListbox : FormElementListControl
    {
        #region Class Constructors
        //***************************************************************************
        // Class Constructors
        // 
        internal FormElementListbox(FormElementData data)
            : base(data)
        { }
        #endregion

        #region Private Methods
        //***************************************************************************
        // Private Methods
        // 
        protected override void CreateChildControls()
        {
            Panel pnl = FormElementControl.CreateControlContainer(this._qData, this.EditMode);
            this.Controls.Add(pnl);
            this.ControlContainer = pnl;

            ListBox lst = new ListBox();
            pnl.Controls.Add(lst);
            lst.ID = "lstElement_" + this._qData.ElementProviderKey.ToString();
            lst.ValidationGroup = "DynamicForm_" + this._qData.FormProviderKey.ToString();
            if (this._qData.ElementWidth != Unit.Empty)
                lst.Width = this._qData.ElementWidth;
            if (this._qData.ElementHeight != Unit.Empty)
                lst.Height = this._qData.ElementHeight;
            foreach (FormElementDataAnswer item in this._qData.Answers.OrderBy(a => a.OrdinalPosition))
                lst.Items.Add(new ListItem(item.AnswerText, item.AnswerProviderKey.ToString()));
            this.AnswerControl = lst;

            base.CreateChildControls();
        }
        #endregion
    }
}
